using UnityEngine;

namespace aburron.Controllers
{
	public class GameController : MonoBehaviour
	{
		[SerializeField] private float gameDuration = 40.0f;

		private void Awake()
		{
			Events.GameEvents.onGameWon += FinishGame;
			Events.GameEvents.onExitDoor += StartFinishTimer;
		}

		private void StartFinishTimer()
		{
			Utils.AbuTimer.Play(gameDuration, FinishGame);
		}

		private void FinishGame()
		{
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#else
			Application.Quit();
			#endif
		}

		private void OnDestroy()
		{
			Events.GameEvents.onGameWon -= FinishGame;
			Events.GameEvents.onExitDoor -= StartFinishTimer;
		}

	}
}