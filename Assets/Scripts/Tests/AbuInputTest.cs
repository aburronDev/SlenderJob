using UnityEngine;
using aburron.Input;

public class AbuInputTest : MonoBehaviour
{
	private AbuInput input = new AbuInput();

	public void Awake()
	{
		input.Enable();

		input.onActionBottomRow1 += TestInput;
	}

	private void TestInput(float inputValue) => Debug.Log($"AbuInput is working: {inputValue}");

	public void OnDestroy()
	{
		input.Disable();

		input.onActionBottomRow1 -= TestInput;
	}
}
