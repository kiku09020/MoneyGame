using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController {
    public class ResultState : GameStateBase {

		[SerializeField] GameDataManager dataManager;

		[SerializeField] ResultScoreTextController scoreText;
		[SerializeField] ResultBestScoreTextController bestScoreText;

		//--------------------------------------------------

		public override void OnEnter()
		{
			dataManager.Load();							// �n�C�X�R�A�ǂݍ���

			// �e�L�X�g�ɔ��f
			scoreText.DispText();
			bestScoreText.DispText();

			// ���U���gUI�\��
			UIManager.ShowUIGroup<ResultUIGroup>();
		}

		public override void OnUpdate()
		{

		}

		public override void OnExit()
		{

		}
	}
}