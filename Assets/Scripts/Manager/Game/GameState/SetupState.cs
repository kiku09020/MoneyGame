using GameController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.Money.MoneyManager;

namespace GameController.State {
	using Cysharp.Threading.Tasks;
	using System;
	using System.Threading;
	using UI.UIController;

    public class SetupState : GameStateBase {

		[Header("Parameters")]
		[SerializeField] float transitionWaitDuration = 3;

		[Header("Components")]
		[SerializeField] MoneyGenerator generator;
		[SerializeField] GameStateMachine state;

		[Header("TextControllers")]
		[SerializeField] GeneratableTextController readyTextController;
		[SerializeField] GeneratableTextController startTextController;

		bool onceActionFlag ;

		CancellationToken token;

		//--------------------------------------------------

		public override void OnEnter()
		{
			token=this.GetCancellationTokenOnDestroy();
			generator.GenerateAndMove();
		}

		public override void OnUpdate()
		{
			if (!MoneyGenerator.IsGenerating && !onceActionFlag) {
				//readyTextController.PlayAnimation();

				TransitionToMainState();
				onceActionFlag = true;
			}
		}

		public override void OnExit()
		{

		}

		// ÉÅÉCÉìèÛë‘Ç…ëJà⁄
		async void TransitionToMainState()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(transitionWaitDuration), cancellationToken: token);

			state.StateTransition<MainState>();
		}
	}
}