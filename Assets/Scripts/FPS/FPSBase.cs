using UnityEngine;

[RequireComponent(typeof(FPSController))]
public abstract class FPSBase : MonoBehaviour
{
	protected FPSController player;

	#region MonoBehaviour Callbacks
	protected virtual void Awake()
	{
		player = GetComponent<FPSController>();

		EnableInput();
	}

	protected virtual void OnDestroy()
	{
		DisableInput();
	}
	#endregion

	public abstract void EnableInput();
	public abstract void DisableInput();
}
