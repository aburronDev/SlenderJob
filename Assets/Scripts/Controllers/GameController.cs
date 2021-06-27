using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace aburron.Controllers
{
	public class GameController : MonoBehaviour
	{
		[SerializeField] private float gameDuration = 600.0f;

		private void Awake()
		{
			Events.GameEvents.onGameWon += FinishGame;
			//Events.GameEvents.onGameLost += RestartGame;
		}

		private void Start()
		{
			//Utils.AbuTimer.Play(gameDuration, RestartGame);
		}


		private void FinishGame()
		{
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#else
			Application.Quit();
			#endif
		}

		private void RestartGame()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

	}
}