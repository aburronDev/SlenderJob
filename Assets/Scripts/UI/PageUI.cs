using UnityEngine;

namespace aburron.UI
{
	public class PageUI : MonoBehaviour
	{
		private Input.AbuInput input = new Input.AbuInput();

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