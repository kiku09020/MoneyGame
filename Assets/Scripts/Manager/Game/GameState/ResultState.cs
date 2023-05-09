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
			dataManager.Load();							// ハイスコア読み込み

			// テキストに反映
			scoreText.DispText();
			bestScoreText.DispText();

			// リザルトUI表示
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