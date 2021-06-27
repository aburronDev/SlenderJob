using UnityEngine;

namespace aburron.Audio
{
	public class KnockAudio : MonoBehaviour
	{
		[SerializeField, FMODUnity.EventRef] private string soundEvent;

		private FMOD.Studio.EventInstance instance;

		private void Awake()
		{
			Events.GameEvents.onFirstPageTaken += LoopSound;
		}

		private void LoopSound()
		{
			instance = FMODUnity.RuntimeManager.CreateInstance(soundEvent);
			instance.start();
		}

		private void StopDialogue()
		{
			instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		}
	}
}