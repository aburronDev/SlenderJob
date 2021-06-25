using UnityEngine;

namespace aburron.Utils
{
	public class CursorSettings : MonoBehaviour
	{
		[SerializeField] CursorLockMode cursorLockMode = CursorLockMode.Locked;
		[SerializeField] bool isVisible = false;

		private void Start()
		{
			Cursor.lockState = cursorLockMode;
			Cursor.visible = isVisible;
		}
	}
}