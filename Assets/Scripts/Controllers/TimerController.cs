using UnityEngine;

namespace aburron.Controllers
{
	public class TimerController : MonoBehaviour
	{
		[SerializeField] private int timerAmount = 10;

		private void Start()
		{
			Utils.AbuTimer.Start(timerAmount);
		}

		private void Update()
		{
			Utils.AbuTimer.Update();
		}
	}
}