using UnityEngine;
using aburron.Editor;

namespace aburron.FPS
{
	public class FPSCameraLook : FPSBase
	{
		private const float camLimit = 90.0f;

		[SerializeField, Required] private Camera cam = null;
		[SerializeField] private float mouseSensitivity = 3.5f;
		[SerializeField, Range(0.0f, 0.5f)] private float smoothTime = 0.03f;

		private Vector2 lookDir = new Vector2();
		private Vector2 lookDelta = new Vector2();
		private Vector2 lookVelocity = new Vector2();

		private float camPitch = 0.0f;

		#region MonoBehaviour Callbacks
		private void Update()
		{
			Look();
		}
		#endregion

		#region Input Callbacks
		private void UpdateLookDir(Vector2 inputDir) => lookDir = inputDir;
		#endregion

		#region CameraLook Callbacks
		private void Look()
		{
			lookDelta = Vector2.SmoothDamp(lookDelta, lookDir, ref lookVelocity, smoothTime);

			camPitch -= lookDelta.y * mouseSensitivity;
			camPitch = Mathf.Clamp(camPitch, -camLimit, camLimit);

			cam.transform.localEulerAngles = Vector3.right * camPitch;
			transform.Rotate(Vector3.up * lookDelta.x * mouseSensitivity);
		}
		#endregion

		public override void EnableInput()
		{
			player.Input.onRightStick += UpdateLookDir;
		}

		public override void DisableInput()
		{
			player.Input.onRightStick -= UpdateLookDir;
		}
	}
}