using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameController {
    public class GameEndState :GameStateBase
    {
		[Header("Components")]
		[SerializeField] GameStateMachine state;

		[SerializeField] int endDuration;
		[SerializeField] FinishTextController finishText;

		//--------------------------------------------------

		public override void OnEnter()
		{
			MainGameManager.isOperable = false;		// ����s�\�ɂ���

			finishText.StartingAction();

			Wait();
		}

		public override void OnUpdate()
		{

		}

		public override void OnExit()
		{

		}

		async void Wait()
		{
			await UniTask.DelayFrame(endDuration);

			state.StateTransition<ResultState>();		// ���ʏ�ԂɑJ��
		}
	}
}