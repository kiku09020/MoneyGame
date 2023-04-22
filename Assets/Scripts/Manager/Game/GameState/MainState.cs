using DG.Tweening;
using GameController;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace GameController {
    public class MainState : GameStateBase {
		[SerializeField] GameStateMachine state;
		[SerializeField] RectTransform gameInfoUI;

		//--------------------------------------------------

		private void Awake()
		{
			gameInfoUI.localScale = Vector3.zero;

			GameTimer.Enabled = false;
		}

		public override void OnEnter()
		{
			gameInfoUI.DOScale(1, .5f);

			GameTimer.Enabled = true;			// �^�C�}�[�L����
			MainGameManager.isOperable = true;	// ����\�ɂ���
		}

		public override void OnUpdate()
		{
			// �Q�[���I�����ɏI����ԂɑJ�ڂ���
			if (MainGameManager.isGameEnd) {
				state.StateTransition<GameEndState>();
			}
		}

		public override void OnExit()
		{

		}
	}
}