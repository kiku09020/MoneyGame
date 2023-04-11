using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMatchineBase<T> :MonoBehaviour where T: notnull, IStateBase
{
	/// <summary>
	/// 現在の状態
	/// </summary>
	public T NowState { get; protected set; }

	public List<T> stateList = new List<T>();

	/// <summary>
	/// 状態の初期化
	/// </summary>
	/// /// <param name="initState">初期状態</param>
    public void StateInit(int index)
    {
		NowState = CheckList(index);
		NowState.EnterEvent?.Invoke();
    }

	public void StateInit(string name)
	{
		NowState= CheckList(name);
		NowState.EnterEvent?.Invoke();
	}

    /// <summary>
    /// 現在の状態の更新処理
    /// </summary>
    public void StateUpdate()
	{
		NowState.UpdateEvent?.Invoke();
	}

	/// <summary>
	/// 状態遷移
	/// </summary>
	/// <param name="index">状態リストの要素番号</param>
	public void StateTransition(int index)
	{
		NowState.ExitEvent?.Invoke();
		NowState = CheckList(index);
		NowState.EnterEvent?.Invoke();
	}

	public void StateTransition(string name)
	{
		NowState.ExitEvent?.Invoke();
		NowState = CheckList(name);
		NowState.EnterEvent?.Invoke();
	}

	// リストに指定された要素番号の要素があるかどうか。あればその要素番号の状態を返す
	T CheckList(int index)
	{
		if (0 <= index && index < stateList.Count) {
			return stateList[index];
		}

		throw new System.Exception("存在しない要素番号が指定されました");
	}

	// リスト内に指定された名前の要素があるかどうか。あればその名前の状態を返す
	T CheckList(string name)
	{
		foreach(var state in stateList) {
			if (state.Name == name) {
				return state;
			}
		}

		throw new System.Exception("指定された名前の要素はありません。");
	}
}
