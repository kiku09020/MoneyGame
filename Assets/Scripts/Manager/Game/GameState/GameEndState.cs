using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController {
    public class GameEndState :GameStateBase
    {
		[Header("Components")]
		[SerializeField] GameStateMachine state;
		[SerializeField] FinishTextController finishText;
		[SerializeField] GameDataManager dataManager; 

		[Header("Parameters")]
		[SerializeField,Tooltip("終了後の待機時間")] int endWaitDuration;

		//--------------------------------------------------

		public override void OnEnter()
		{
			MainGameManager.isOperable = false;		// 操作不能にする

			finishText.StartingAction();			// 終了テキストのアニメーション開始

			TransitionToResult();
		}

		public override void OnUpdate()
		{

		}

		public override void OnExit()
		{

		}

		// 結果状態に遷移
		async void TransitionToResult()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(endWaitDuration));     // 待機

			dataManager.Save();												// ハイスコア保存

			state.StateTransition<ResultState>();							// 遷移
		}
	}
}