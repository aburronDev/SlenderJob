using UnityEngine;

namespace aburron.FPS
{
	public class FPSFootsteps : FPSBase
	{
		[FMODUnity.EventRef]
		[SerializeField] private string inputSound = string.Empty;
		[SerializeField] private float soundSpeed = 1.0f;

		private bool footstepEventConditionIsValid = false;

		#region MonoBehaviours Callbacks
		private void Start()
		{
			InvokeRepeating(nameof(PlaySound), 0, soundSpeed);
		}
		#endregion

		#region Input Callbacks
		private void CheckFootstepEventCondition(Vector2 inputAxis)
		{
			footstepEventConditionIsValid = (inputAxis.x >= 0.01f || inputAxis.y >= 0.01f || inputAxis.x <= -0.01f || inputAxis.y <= -0.01f);
		}
		#endregion

		#region Update Callbacks
		private void PlaySound()
		{
			if (!footstepEventConditionIsValid)
				return;

			FMODUnity.RuntimeManager.PlayOneShot(inputSound);
		}
		#endregion

		public override void EnableInput()
		{
			player.Input.onLeftStick += CheckFootstepEventCondition;
		}

		public override void DisableInput()
		{
			footstepEventConditionIsValid = false;

			player.Input.onLeftStick -= CheckFootstepEventCondition;
		}
	}
}