using UnityEngine;

public class ExitDoor : MonoBehaviour
{
	private bool triggerExitActivated = false;

	private void Awake()
	{
		aburron.Events.GameEvents.onAllPagesTaken += ActivateTriggerExit;
	}

	private void ActivateTriggerExit() => triggerExitActivated = true;

	private void OnTriggerEnter(Collider other)
	{
		if (triggerExitActivated)
			aburron.Events.GameEvents.onGameWon?.Invoke();
	}
}
