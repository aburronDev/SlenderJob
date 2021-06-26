using UnityEngine;

namespace aburron.AI
{
	public class IreneAI : MonoBehaviour
	{
		[SerializeField, Editor.Required] private Transform target;
		[SerializeField] private float vision = 0.8f;
		[Space]
		[Header("Random Spawn Angle")]
		[SerializeField] private float minSpawnAngle = 0.0f;
		[SerializeField] private float maxSpawnAngle = 360.0f;
		[Header("Random Spawn Distance")]
		[SerializeField] private float minSpawnDistance = 10.0f;
		[SerializeField] private float maxSpawnDistance = 20.0f;
		[Header("Time Unseen")]
		[SerializeField] private float maxTimeUnseen = 4.0f;

		private float timeUnseen;

		private void Update()
		{
			if (SeenByTarget())
			{
				timeUnseen = 0;
			}
			else
			{
				timeUnseen += Time.deltaTime;
			}

			if (timeUnseen > maxTimeUnseen)
			{
				timeUnseen = 0.0f;
				ChangePosition();
			}
		}

		private bool SeenByTarget()
		{
			var forward = target.forward;
			var offset = (transform.position - target.position).normalized;

			return (Vector3.Dot(forward, offset) > vision);
		}

		private void ChangePosition()
		{
			var randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
			var randomAngle = Random.Range(minSpawnAngle, maxSpawnAngle);

			var skyDir = new Vector3(
				randomDistance * Mathf.Cos(randomAngle),
				50.0f,
				randomDistance * Mathf.Sin(randomAngle)
				);

			var spawnPos = target.position + skyDir;

			var ray = new Ray(spawnPos, Vector3.down);

			if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
			{
				if (hitInfo.collider == null)
					return;

				transform.position = new Vector3(hitInfo.point.x, 2.0f, hitInfo.point.z);
			}
		}
	}
}