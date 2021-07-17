using UnityEngine;

namespace aburron.Effect
{
	public class GroundOffset : MonoBehaviour
	{
		[SerializeField] private Renderer rend;
		[SerializeField] private float offsetSpeed;

		private Input.AbuInput input = new Input.AbuInput();

		private Vector4 offsetDir = Vector4.zero;

		private void OnEnable()
		{
			input.Enable();
		}

		private void Awake()
		{
			input.onLeftStick += Move;
		}

		private void Move(Vector2 _Offset)
		{
			offsetDir.Set(_Offset.x, _Offset.y, 0.0f, 0.0f);

			rend.material.SetVector(nameof(_Offset), offsetDir * offsetSpeed);
		}

		private void OnDisable()
		{
			input.Disable();
		}

		private void OnDestroy()
		{
			input.onLeftStick -= Move;
		}
	}
}