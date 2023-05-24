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
			dataManager.Load();							// ハイスコア読み込み

			// テキストに反映
			//scoreTextController.PlayAllAnimations();
			//bestScoreTextController.PlayAllAnimations();

			// リザルトUI表示
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