using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.State {

	using UI.UIController;

    public class GameEndState :GameStateBase
    {
		[Header("Components")]
		[SerializeField] GameStateMachine state;
		//[SerializeField] TextController textController;
		[SerializeField] GameDataManager dataManager; 

		[Header("Parameters")]
		[SerializeField,Tooltip("�I����̑ҋ@����")] int endWaitDuration;

		//--------------------------------------------------

		public override void OnEnter()
		{
			MainGameManager.isOperable = false;		// ����s�\�ɂ���

			// �I���e�L�X�g�\��

			TransitionToResult();
		}

		public override void OnUpdate()
		{

		}

		public override void OnExit()
		{

		}

		// ���ʏ�ԂɑJ��
		async void TransitionToResult()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(endWaitDuration));     // �ҋ@

			dataManager.Save();												// �n�C�X�R�A�ۑ�

			state.StateTransition<ResultState>();							// �J��
		}
	}
}