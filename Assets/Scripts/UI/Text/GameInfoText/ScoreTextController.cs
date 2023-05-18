using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameController.UI.TextController {
	public class ScoreTextController : GeneratableTextController {
		[Header("Components")]
		[SerializeField] TextMeshProUGUI totalScoreText;

		private void Awake()
		{
			totalScoreText.text = "0";
		}

		protected override string SetMessage(float value)
		{
			SetTotalScoreText();        // 合計スコアのテキストも更新する

			// 桁区切り
			var text = ScoreManager.GetScoreString((int)value * ScoreManager.ComboCount);

			return $"+{text}";
		}

		// 合計スコアのテキストの変更
		void SetTotalScoreText()
		{
			totalScoreText.text = ScoreManager.GetScoreString();
		}
	}
}