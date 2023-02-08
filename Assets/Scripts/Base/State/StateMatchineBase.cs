using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMatchineBase<T> :MonoBehaviour where T:IStateBase
{
	/// <summary>
	/// Œ»İ‚Ìó‘Ô
	/// </summary>
	public T NowState { get; protected set; }

	/// <summary>
	/// ó‘Ô‚Ì‰Šú‰»
	/// </summary>
	/// /// <param name="initState">‰Šúó‘Ô</param>
	public void StateInit(T state)
	{
		NowState = state;
		NowState.StateEnter();
	}

	/// <summary>
	/// Œ»İ‚Ìó‘Ô‚ÌXVˆ—
	/// </summary>
	public void StateUpdate()
	{
		NowState.StateUpdate();
	}

	/// <summary>
	/// ó‘Ô‘JˆÚ
	/// </summary>
	/// <param name="nextState">Ÿ‚Ìó‘Ô</param>
	public void StateTransition(T nextState)
	{
		NowState.StateExit();
		NowState = nextState;
		NowState.StateEnter();
	}

}
