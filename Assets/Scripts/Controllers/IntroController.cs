using UnityEngine;
using UnityEngine.SceneManagement;

namespace aburron.Controllers
{
	public class IntroController : MonoBehaviour
	{
		[SerializeField, FMODUnity.EventRef] private string soundEvent;
		[SerializeField] private float introDuration = 13.0f;

		private void Start()
		{
			FMODUnity.RuntimeManager.PlayOneShot(soundEvent);
			Utils.AbuTimer.Play(introDuration, () => SceneManager.LoadScene(1));
		}
	}
}