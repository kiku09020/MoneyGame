using GameController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.Money.MoneyManager;

namespace GameController.State {

	using UI.TextController;

    public class SetupState : GameStateBase {
		[SerializeField] MoneyGenerator generator;
		[SerializeField] GameStateMachine state;
		[SerializeField] ReadyTextController textController;

		bool onceActionFlag ;

		//--------------------------------------------------

		public override void OnEnter()
		{
			generator.GenerateAndMove();
		}

		public override void OnUpdate()
		{
			if (!MoneyGenerator.IsGenerating && !onceActionFlag) {
				textController.StartingAction();
				onceActionFlag = true;
			}
		}

		public override void OnExit()
		{

		}
	}
}