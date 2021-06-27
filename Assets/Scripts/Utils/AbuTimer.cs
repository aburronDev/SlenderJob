using System.Collections.Generic;
using UnityEngine;

namespace aburron.Utils
{
	public class TimerParams
	{
		private object[] paramsData;
		public object[] ParamsData { get => paramsData; set => paramsData = value; }
	}

	public class Timer
	{
		public delegate void OnCompleteEvent();
		public OnCompleteEvent OnComplete;

		public delegate void OnCompleteParamsEvent();
		public OnCompleteParamsEvent OnCompleteParams;

		private bool enabled = false;
		private float waitTime = 1.0f;
		private float currentTime = 0.0f;

		private TimerParams timerParams = new TimerParams();

		public bool Enabled { get => enabled; set => enabled = value; }

		public void SetTimerCompleted(OnCompleteEvent callback)
		{
			OnCompleteParams = null;
			OnComplete = callback;
		}

		public void SetTimerParamsCompleted(OnCompleteParamsEvent callback, params object[] args)
		{
			OnComplete = null;
			OnCompleteParams = callback;
			timerParams.ParamsData = args;
		}

		public void Start(float waitTime, bool enabled)
		{
			this.waitTime = waitTime;
			currentTime = 0;
			this.enabled = enabled;
		}

		public void StartParams(float waitTime, bool enabled, params object[] args)
		{
			timerParams.ParamsData = args;

			this.waitTime = waitTime;
			currentTime = 0;
			this.enabled = enabled;
		}

		public void Update()
		{
			if (enabled)
			{
				currentTime += Time.deltaTime;

				if (!(currentTime >= waitTime)) return;

				currentTime = 0;
				enabled = false;

				OnComplete?.Invoke();
			}
		}

		public void Pause(bool state)
		{
			enabled = enabled == !state ? state : !state;
		}

		public void Stop()
		{
			enabled = false;
			waitTime = 0;
			currentTime = 0;
		}
	}

	public static class AbuTimer
	{
		private static List<Timer> timerList;

		public static bool TimerManagerWasInitiated()
		{
			if (timerList == null)
				return false;

			if (timerList.Count > 0)
				return true;

			return false;
		}

		public static void Start(int timersAmount)
		{
			timerList = new List<Timer>();

			for (int i = 0; i < timersAmount; ++i)
			{
				var timer = new Timer();
				timer.Enabled = false;
				timerList.Add(timer);
			}
		}

		public static void Update()
		{
			for (int i = 0, max = timerList.Count; i < max; ++i)
			{
				var timer = timerList[i];

				if (timer.Enabled)
					timer.Update();
			}
		}

		public static bool Play(float timerValue, Timer.OnCompleteEvent callback)
		{
			var timerNotFound = false;

			for (int i = 0, max = timerList.Count; i < max; ++i)
			{
				var timer = timerList[i];

				if (!timer.Enabled)
				{
					timer.SetTimerCompleted(callback);
					timer.Start(timerValue, true);

					return true;
				}
				else timerNotFound = true;
			}
			if (timerNotFound)
			{
				var timer = new Timer();

				timer.Enabled = false;
				timerList.Add(timer);

				timer.SetTimerCompleted(callback);
				timer.Start(timerValue, true);

				return true;
			}

			return false;
		}

		public static bool PlayParams(float timerValue, Timer.OnCompleteParamsEvent callback, params object[] args)
		{
			var timerNotFound = false;

			for (int i = 0, max = timerList.Count; i < max; ++i)
			{
				var timer = timerList[i];

				if (!timer.Enabled)
				{
					timer.SetTimerParamsCompleted(callback, args);
					timer.StartParams(timerValue, true, args);

					return true;
				}
				else timerNotFound = true;
			}
			if (timerNotFound)
			{
				var timer = new Timer();

				timer.Enabled = false;
				timerList.Add(timer);

				timer.SetTimerParamsCompleted(callback, args);
				timer.StartParams(timerValue, true, args);

				return true;
			}

			return false;
		}

		public static void PauseAll(bool state)
		{
			for (int i = 0, max = timerList.Count; i < max; ++i)
			{
				var timer = timerList[i];

				timer.Pause(state);
			}
		}

		public static void StopAll()
		{
			for (int i = 0, max = timerList.Count; i < max; ++i)
			{
				var timer = timerList[i];

				timer.Stop();
				timer.SetTimerCompleted(null);
			}
		}

		public static void Pause(bool state, Timer.OnCompleteEvent callback)
		{
			for (int i = 0, max = timerList.Count; i < max; ++i)
			{
				var timer = timerList[i];

				if (!timer.Enabled)
					continue;

				if (timer.OnComplete != callback)
					continue;

				timer.SetTimerCompleted(null);
				timer.SetTimerParamsCompleted(null, null);
				timer.Pause(state);
				break;
			}
		}

		public static void PauseParams(bool state, Timer.OnCompleteParamsEvent callback)
		{
			for (int i = 0, max = timerList.Count; i < max; ++i)
			{
				var timer = timerList[i];

				if (!timer.Enabled)
					continue;

				if (timer.OnCompleteParams != callback)
					continue;

				timer.SetTimerCompleted(null);
				timer.SetTimerParamsCompleted(null, null);
				timer.Pause(state);
				break;
			}
		}

		public static void Stop(Timer.OnCompleteEvent callback)
		{
			for (int i = 0, max = timerList.Count; i < max; ++i)
			{
				var timer = timerList[i];

				if (!timer.Enabled)
					continue;

				if (timer.OnComplete != callback)
					continue;

				timer.SetTimerCompleted(null);
				timer.SetTimerParamsCompleted(null, null);
				timer.Stop();
				break;
			}
		}

		public static void StopParams(Timer.OnCompleteParamsEvent callback)
		{
			for (int i = 0, max = timerList.Count; i < max; ++i)
			{
				var timer = timerList[i];

				if (!timer.Enabled)
					continue;

				if (timer.OnCompleteParams != callback)
					continue;

				timer.SetTimerCompleted(null);
				timer.SetTimerParamsCompleted(null, null);
				timer.Stop();
				break;
			}
		}

		public static void Destroy()
		{
			for (int i = 0, max = timerList.Count; i < max; ++i)
			{
				if (timerList[i] != null)
				{
					timerList[i].Stop();
					timerList[i].SetTimerCompleted(null);
				}
			}

			timerList.Clear();
		}
	}
}