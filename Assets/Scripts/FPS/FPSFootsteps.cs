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
		protected override void Awake()
		{
			base.Awake();

			Events.GameEvents.onPageInteraction += PauseSound;
			Events.GameEvents.onPageTaken += ResumeSound;
		}

		private void Start()
		{
			ResumeSound();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			Events.GameEvents.onPageInteraction -= PauseSound;
			Events.GameEvents.onPageTaken -= ResumeSound;
		}
		#endregion

		#region Input Callbacks
		private void CheckFootstepEventCondition(Vector2 inputAxis)
		{
			footstepEventConditionIsValid = (inputAxis.x >= 0.01f || inputAxis.y >= 0.01f || inputAxis.x <= -0.01f || inputAxis.y <= -0.01f);
		}
		#endregion

		#region Footsteps Callbacks
		private void PlaySound()
		{
			if (!footstepEventConditionIsValid)
				return;

			FMODUnity.RuntimeManager.PlayOneShot(inputSound);
		}

		private void PauseSound(int _) => CancelInvoke();
		private void ResumeSound() => InvokeRepeating(nameof(PlaySound), 0, soundSpeed);
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