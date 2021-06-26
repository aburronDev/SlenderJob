using UnityEngine;
using aburron.Editor;

public class Billboard : MonoBehaviour
{
	[SerializeField, Required] private Transform cam;

	private void Update()
	{
		var camPos = cam.position;
		camPos.y = 0.0f;

		var pos = transform.position;
		pos.y = 0.0f;

		var dirToCamera = (camPos - pos).normalized;
		var angleToCamera = GetAngleFromVector(dirToCamera);

		transform.eulerAngles = new Vector3(0f, -angleToCamera + 90 + 180, 0f);
	}

	private float GetAngleFromVector(Vector3 dir)
	{
		dir = dir.normalized;

		var angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
		if (angle < 0) angle += 360;

		return angle;
	}
}
