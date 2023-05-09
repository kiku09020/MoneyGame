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
		[SerializeField,Tooltip("�I����̑ҋ@����")] int endWaitDuration;

		//--------------------------------------------------

		public override void OnEnter()
		{
			MainGameManager.isOperable = false;		// ����s�\�ɂ���

			finishText.StartingAction();			// �I���e�L�X�g�̃A�j���[�V�����J�n

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