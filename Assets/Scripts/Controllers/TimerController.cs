using UnityEngine;

namespace aburron.Controllers
{
	public class TimerController : MonoBehaviour
	{
		private void Start()
		{
			Utils.AbuTimer.Start(10);
		}

		private void Update()
		{
			Utils.AbuTimer.Update();
		}
	}
}