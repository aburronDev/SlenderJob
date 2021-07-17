using UnityEngine;

namespace aburron.Utils
{
	public class ObjectStart : MonoBehaviour
	{
		[SerializeField, Editor.Required] private Transform startPoint;

		private void Start()
		{
			transform.position = startPoint.position;
		}
	}
}