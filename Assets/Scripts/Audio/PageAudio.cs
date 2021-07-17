using UnityEngine;

namespace aburron.Audio
{
	public class PageAudio : MonoBehaviour
	{
		[SerializeField, FMODUnity.EventRef] private System.Collections.Generic.List<string> dialogues;

		private FMOD.Studio.EventInstance instance;

		private void Awake()
		{
			Events.GameEvents.onPageInteraction += PlayDialogue;
			Events.GameEvents.onPageTaken += StopDialogue;
		}

		private void PlayDialogue(int dialogueIndex)
		{
			instance = FMODUnity.RuntimeManager.CreateInstance(dialogues[dialogueIndex - 1]);
			instance.start();
		}

		private void StopDialogue()
		{
			instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		}
	}
}