using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.TextController {
	public class ResultBestScoreTextController : ResultTextController {
		[Header("Components")]
		[SerializeField] GameDataManager dataManager;

		//--------------------------------------------------

		/// <summary>
		/// ハイスコアを表示
		/// </summary>
		public override void DispText()
		{
			var message = ScoreManager.GetScoreString(dataManager.GameData.highScore);

			DispText(message);
		}
	}
}