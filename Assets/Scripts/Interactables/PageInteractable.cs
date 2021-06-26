using UnityEngine;

namespace aburron.Interactable
{
	public class PageInteractable : MonoBehaviour, Interface.IInteractable
	{
		public void Interact()
		{
			gameObject.SetActive(false);
		}
	}
}