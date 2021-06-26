using UnityEngine;

namespace aburron.FPS
{
	public class FPSMovement : FPSBase
	{
		[SerializeField] private float walkSpeed = 6.0f;
		[SerializeField, Range(0.0f, 0.5f)] private float smoothTime = 0.01f;

		private Vector2 moveDir = new Vector2();
		private Vector2 smoothDir = new Vector2();
		private Vector2 currentVelocity = new Vector2();

		private float moveSpeed = 0.0f;

		#region MonoBehaviours Callbacks
		private void Start()
		{
			moveSpeed = walkSpeed;
		}

		private void FixedUpdate()
		{
			Move();
		}

		private void OnValidate()
		{
			moveSpeed = walkSpeed;
		}
		#endregion

		#region Input Callbacks
		private void UpdateMoveDir(Vector2 inputDir) => moveDir = inputDir;
		#endregion

		#region Update Callbacks
		private void Move()
		{
			moveDir.Normalize();

			smoothDir = Vector2.SmoothDamp(smoothDir, moveDir, ref currentVelocity, smoothTime);

			var moveVelocity = (transform.right * smoothDir.x + transform.forward * smoothDir.y).normalized * moveSpeed;

			if (moveVelocity != Vector3.zero)
				player.Move(player.Position + moveVelocity * Time.fixedDeltaTime);
		}
		#endregion

		public override void EnableInput()
		{
			player.Input.onLeftStick += UpdateMoveDir;
		}

		public override void DisableInput()
		{
			player.Input.onLeftStick -= UpdateMoveDir;
		}
	}
}