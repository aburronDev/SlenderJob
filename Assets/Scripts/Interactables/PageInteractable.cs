using UnityEngine;

namespace aburron.Interactable
{
	public class PageInteractable : MonoBehaviour, Interface.IInteractable
	{
		private static int pageAmount = 0;

		public void Interact()
		{
			gameObject.SetActive(false);
			pageAmount++;
			Events.GameEvents.onPageInteraction?.Invoke(pageAmount);
		}
	}
}