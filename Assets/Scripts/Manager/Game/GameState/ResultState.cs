using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.State {

	using UI.UIGroup;
	using UI.UIController;

    public class ResultState : GameStateBase {

		[SerializeField] GameDataManager dataManager;

		//[SerializeField] TextController scoreTextController;
		//[SerializeField] TextController bestScoreTextController;

		//--------------------------------------------------

		public override void OnEnter()
		{
			dataManager.Load();							// �n�C�X�R�A�ǂݍ���

			// �e�L�X�g�ɔ��f
			//scoreTextController.PlayAllAnimations();
			//bestScoreTextController.PlayAllAnimations();

			// ���U���gUI�\��
			UIGroupManager.ShowUIGroup<ResultUIGroup>();
		}

		public override void OnUpdate()
		{

		}

		public override void OnExit()
		{

		}
	}
}