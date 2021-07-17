using UnityEngine;

namespace aburron.Triggers
{
	public class ExitDoorTrigger : MonoBehaviour
	{
		private bool triggerExitActivated = false;

		private void Awake()
		{
			Events.GameEvents.onAllPagesTaken += ActivateTriggerExit;
		}

		private void ActivateTriggerExit() => triggerExitActivated = true;

		private void OnTriggerEnter(Collider other)
		{
			if (triggerExitActivated)
				Events.GameEvents.onExitDoor?.Invoke();
		}

		private void OnDestroy()
		{
			Events.GameEvents.onAllPagesTaken -= ActivateTriggerExit;
		}
	}
}