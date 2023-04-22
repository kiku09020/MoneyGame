using GameController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController {
    public class SetupState : GameStateBase {
		[SerializeField] MoneyGenerator generator;
		[SerializeField] GameStateMachine state;
		[SerializeField] ReadyTextController textController;

		//--------------------------------------------------

		public override void OnEnter()
		{
			generator.GenerateAndMove();
		}

		public override void OnUpdate()
		{
			// 生成終了後に遷移
			if (!MoneyGenerator.IsGenerating) {
				state.StateTransition<MainState>();
			}
		}

		public override void OnExit()
		{
			textController.StartingAction();
		}
	}
}