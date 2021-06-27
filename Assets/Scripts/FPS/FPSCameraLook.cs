using UnityEngine;

namespace aburron.FPS
{
	public class FPSCameraLook : FPSBase
	{
		private const float camLimit = 90.0f;

		[SerializeField, Editor.Required] private Camera cam = null;
		[SerializeField] private float mouseSensitivity = 3.5f;
		[SerializeField, Range(0.0f, 0.5f)] private float smoothTime = 0.03f;

		private Vector2 lookDir = new Vector2();
		private Vector2 lookDelta = new Vector2();
		private Vector2 lookVelocity = new Vector2();

		private float camPitch = 0.0f;
		private float sensitivity = 0.0f;

		#region MonoBehaviour Callbacks

		protected override void Awake()
		{
			base.Awake();

			Events.GameEvents.onPageInteraction += Freeze;
			Events.GameEvents.onPageTaken += UnFreeze;
		}


		private void Start()
		{
			UnFreeze();
		}

		private void Update()
		{
			Look();
		}

		private void OnValidate()
		{
			UnFreeze();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			Events.GameEvents.onPageInteraction -= Freeze;
			Events.GameEvents.onPageTaken -= UnFreeze;
		}
		#endregion

		#region Input Callbacks
		private void UpdateLookDir(Vector2 inputDir) => lookDir = inputDir;
		#endregion

		#region CameraLook Callbacks
		private void Look()
		{
			lookDelta = Vector2.SmoothDamp(lookDelta, lookDir, ref lookVelocity, smoothTime);

			camPitch -= lookDelta.y * sensitivity;
			camPitch = Mathf.Clamp(camPitch, -camLimit, camLimit);

			cam.transform.localEulerAngles = Vector3.right * camPitch;
			transform.Rotate(Vector3.up * lookDelta.x * sensitivity);
		}

		private void Freeze(int _) => sensitivity = 0;
		private void UnFreeze() => sensitivity = mouseSensitivity;
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