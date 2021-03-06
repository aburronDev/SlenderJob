using UnityEngine;

namespace aburron.FPS
{
	using Input;

	[RequireComponent(typeof(Rigidbody))]
	public class FPSController : MonoBehaviour
	{
		private Rigidbody controller;
		private AbuInput input = new AbuInput();

		public AbuInput Input { get => input; set => input = value; }

		public Vector3 Position => controller.position;
		public Quaternion Rotation => controller.rotation;

		public void Move(Vector3 position) => controller.MovePosition(position);

		#region MonoBehaviour Callbacks
		private void Awake()
		{
			controller = GetComponent<Rigidbody>();
			Events.GameEvents.onExitDoor += () => input.Disable();

			input.Enable();
		}

		private void OnDestroy()
		{
			input.Disable();
		}
		#endregion
	}
}