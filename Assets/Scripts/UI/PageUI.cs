using UnityEngine;

namespace aburron.UI
{
	using Input;
	using Events;

	public class PageUI : MonoBehaviour
	{
		private AbuInput input = new AbuInput();

		private void OnEnable()
		{
			input.Enable();
			input.onStart += FirePageTakenEventListener;
		}


		private void FirePageTakenEventListener()
		{
			Events.GameEvents.onPageTaken?.Invoke();
		}

		private void OnDisable()
		{
			input.Disable();
			input.onStart -= FirePageTakenEventListener;
		}
	}
}