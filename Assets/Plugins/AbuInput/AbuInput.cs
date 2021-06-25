using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace aburron.Input
{
	public class AbuInput : AbuInputAction.IAbuMapActions
	{
		private AbuInputAction gameInput;

		#region Actions
		public Action<float> onActionBottomRow1;
		public Action<float> onActionBottomRow2;
		public Action<float> onActionTopRow1;
		public Action<float> onActionTopRow2;
		public Action<float> onDPadUp;
		public Action<float> onDPadDown;
		public Action<float> onDPadLeft;
		public Action<float> onDPadRight;
		public Action<float> onLeftStickUp;
		public Action<float> onLeftStickDown;
		public Action<float> onLeftStickLeft;
		public Action<float> onLeftStickRight;
		public Action<float> onLeftStickButton;
		public Action<float> onLeftStickHorizontal;
		public Action<float> onLeftStickVertical;
		public Action<Vector2> onLeftStick;
		public Action<float> onRightStickUp;
		public Action<float> onRightStickDown;
		public Action<float> onRightStickLeft;
		public Action<float> onRightStickRight;
		public Action<float> onRightStickButton;
		public Action<float> onRightStickHorizontal;
		public Action<float> onRightStickVertical;
		public Action<Vector2> onRightStick;
		public Action onLeftBumper;
		public Action onRightBumper;
		public Action onLeftTrigger;
		public Action onRightTrigger;
		public Action onSelect;
		public Action onStart;
		#endregion

		#region Setting Callbacks
		public void Enable()
		{
			gameInput = new AbuInputAction();

			gameInput.abuMap.SetCallbacks(this);
			gameInput.Enable();
		}

		public void Disable()
		{
			gameInput.Disable();
		}
		#endregion

		#region Bottom Row
		public void OnActionBottomRow1(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onActionBottomRow1?.Invoke(context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onActionBottomRow1?.Invoke(context.ReadValue<float>());
		}

		public void OnActionBottomRow2(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onActionBottomRow2?.Invoke(context.ReadValue<float>());
		}
		#endregion

		#region Top Row
		public void OnActionTopRow1(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onActionTopRow1?.Invoke(context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onActionTopRow1?.Invoke(context.ReadValue<float>());
		}

		public void OnActionTopRow2(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onActionTopRow2?.Invoke(context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onActionTopRow2?.Invoke(context.ReadValue<float>());
		}
		#endregion

		#region DPad
		public void OnDPadUp(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onDPadUp?.Invoke(context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onDPadUp?.Invoke(context.ReadValue<float>());
		}

		public void OnDPadDown(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onDPadDown?.Invoke(-context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onDPadDown?.Invoke(context.ReadValue<float>());
		}

		public void OnDPadLeft(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onDPadLeft?.Invoke(-context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onDPadLeft?.Invoke(context.ReadValue<float>());
		}

		public void OnDPadRight(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onDPadRight?.Invoke(context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onDPadRight?.Invoke(context.ReadValue<float>());
		}
		#endregion

		#region LeftStick
		public void OnLeftStickUp(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onLeftStickUp?.Invoke(context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onLeftStickUp?.Invoke(context.ReadValue<float>());
		}

		public void OnLeftStickDown(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onLeftStickDown?.Invoke(context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onLeftStickDown?.Invoke(context.ReadValue<float>());
		}

		public void OnLeftStickLeft(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onLeftStickLeft?.Invoke(context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onLeftStickLeft?.Invoke(context.ReadValue<float>());
		}

		public void OnLeftStickRight(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onLeftStickRight?.Invoke(context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onLeftStickRight?.Invoke(context.ReadValue<float>());
		}

		public void OnLeftStickButton(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onLeftStickButton?.Invoke(context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onLeftStickButton?.Invoke(context.ReadValue<float>());
		}

		public void OnLeftStickHorizontal(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onLeftStickHorizontal?.Invoke(context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onLeftStickHorizontal?.Invoke(context.ReadValue<float>());
		}

		public void OnLeftStickVertical(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onLeftStickVertical?.Invoke(context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onLeftStickVertical?.Invoke(context.ReadValue<float>());
		}

		public void OnLeftStick(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onLeftStick?.Invoke(context.ReadValue<Vector2>());
			if (context.phase == InputActionPhase.Canceled)
				onLeftStick?.Invoke(context.ReadValue<Vector2>());
		}
		#endregion

		#region RightStick
		public void OnRightStickUp(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onRightStickUp?.Invoke(context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onRightStickUp?.Invoke(context.ReadValue<float>());
		}

		public void OnRightStickDown(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onRightStickDown?.Invoke(-context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onRightStickDown?.Invoke(context.ReadValue<float>());
		}

		public void OnRightStickLeft(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onRightStickLeft?.Invoke(-context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onRightStickLeft?.Invoke(context.ReadValue<float>());
		}

		public void OnRightStickRight(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onRightStickRight?.Invoke(context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onRightStickRight?.Invoke(context.ReadValue<float>());
		}

		public void OnRightStickButton(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onRightStickButton?.Invoke(context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onRightStickButton?.Invoke(context.ReadValue<float>());
		}

		public void OnRightStickHorizontal(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onRightStickHorizontal?.Invoke(context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onRightStickHorizontal?.Invoke(context.ReadValue<float>());
		}

		public void OnRightStickVertical(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onRightStickVertical?.Invoke(context.ReadValue<float>());
			if (context.phase == InputActionPhase.Canceled)
				onRightStickVertical?.Invoke(context.ReadValue<float>());
		}

		public void OnRightStick(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onRightStick?.Invoke(context.ReadValue<Vector2>());
			if (context.phase == InputActionPhase.Canceled)
				onRightStick?.Invoke(context.ReadValue<Vector2>());
		}
		#endregion

		#region Bumpers
		public void OnLeftBumper(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onLeftBumper?.Invoke();
		}

		public void OnRightBumper(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onRightBumper?.Invoke();
		}
		#endregion

		#region Triggers
		public void OnLeftTrigger(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onLeftTrigger?.Invoke();
		}

		public void OnRightTrigger(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onRightTrigger?.Invoke();
		}
		#endregion

		#region Select
		public void OnSelect(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onSelect?.Invoke();
		}
		#endregion

		#region Start
		public void OnStart(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
				onStart?.Invoke();
		}
		#endregion
	}
}