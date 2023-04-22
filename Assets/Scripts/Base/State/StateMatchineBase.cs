using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController {
	public abstract class StateMatchineBase<T> : MonoBehaviour where T : StateBase {
		[SerializeField] T initState;
		[SerializeField] protected List<T> states = new List<T>();

		/// <summary>
		/// 現在の状態
		/// </summary>
		public T NowState { get; protected set; }

		//--------------------------------------------------
		/// <summary>
		/// 初期状態セットアップ
		/// </summary>
		public void StateInit()
		{
			NowState = initState;
			NowState.OnEnter();
		}

		//--------------------------------------------------

		/// <summary>
		/// 現在の状態の更新処理
		/// </summary>
		public void StateUpdate()
		{
			NowState.OnUpdate();
		}

		//--------------------------------------------------
		/// <summary>
		/// 状態遷移
		/// </summary>
		/// <param name="state">次の状態</param>
		public void StateTransition(T state)
		{
			NowState.OnExit();
			NowState = state;
			NowState.OnEnter();
		}

		/// <summary>
		/// 状態遷移
		/// </summary>
		public void StateTransition<State>() where State : T
		{
			StateTransition(GetState<State>());
		}

		//--------------------------------------------------

		// State判定
		void CheckState<State>(Action<State> action) where State : T
		{
			foreach (var state in states) {
				if (state is State targetState) {
					action?.Invoke(targetState);
				}
			}
		}

		/// <summary>
		/// 指定した<typeparamref name="State"/>があれば、それを返す
		/// </summary>
		/// <typeparam name="State">目的の状態</typeparam>
		/// <returns>指定された<typeparamref name="State"/></returns>
		public State GetState<State>() where State : T
		{
			State state = default(State);

			CheckState<State>((targetState) => {
				state = targetState;
			});

			return state;
		}
	}
}