using UnityEngine;

namespace aburron.FPS
{
	public class FPSInteractor : FPSBase
	{
		[SerializeField, Editor.Required] private Camera cam = null;
		[SerializeField] private float rayDistance = 3.0f;

		#region Input Callbacks
		private void FireRaycastButton(float buttonValue)
		{
			if (buttonValue == 0)
				return;
			FireRaycast();
		}
		#endregion

		#region Interactor Callbacks
		private void FireRaycast()
		{
			var ray = cam.ScreenToWorldPoint(UnityEngine.InputSystem.Mouse.current.position.ReadValue());

			if (Physics.Raycast(ray, transform.forward, out RaycastHit hitInfo, rayDistance))
			{
				if (hitInfo.transform.TryGetComponent(out Interface.IInteractable interactable))
					interactable.Interact();
			}
		}
		#endregion

		public override void EnableInput()
		{
			player.Input.onActionBottomRow1 += FireRaycastButton;
		}

		public override void DisableInput()
		{
			player.Input.onActionBottomRow1 -= FireRaycastButton;
		}
	}
}