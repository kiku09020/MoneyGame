using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// インスタンスの状態の操作をします。
/// </summary>
public class StateControllerBase : MonoBehaviour
{
	/// <summary>
	/// 現在の状態
	/// </summary>
	public IStateBase NowState { get; private set; }

	/// <summary>
	/// 状態の初期化
	/// </summary>
	/// /// <param name="initState">初期状態</param>
	public void StateInit(IStateBase initState)
	{
		NowState = initState;
		NowState.StateEnter();
	}

	/// <summary>
	/// 現在の状態の更新処理
	/// </summary>
	public void StateUpdate()
	{
		NowState.StateUpdate();
	}

	/// <summary>
	/// 状態遷移
	/// </summary>
	/// <param name="nextState">次の状態</param>
	public void StateTransition(IStateBase nextState)
	{
		NowState.StateExit();
		NowState = nextState;
		NowState.StateEnter();
	}
}
