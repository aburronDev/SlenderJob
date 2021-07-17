using UnityEngine;

namespace aburron.Tests
{
	using AbuTimer = Utils.AbuTimer;

	public class TimerTest : MonoBehaviour
	{
		private void Start()
		{
			AbuTimer.Start(100);
		}

		private void Update()
		{
			AbuTimer.Update();
		}

		private void SendMessage() => Debug.Log("TimerManager works");

		public void PlayTimer() => AbuTimer.Play(3, SendMessage);

		public void PauseTimer() => AbuTimer.Pause(true, SendMessage);

		public void StopTimer() => AbuTimer.Stop(SendMessage);

		public void PauseAllTimers() => AbuTimer.PauseAll(true);

		public void StopAllTimmers() => AbuTimer.StopAll();
	}
}