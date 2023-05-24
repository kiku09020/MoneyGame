using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameController.UI.UIController {
	public class AddedScoreTextController : GeneratableTextController {
		[Header("Components")]
		[SerializeField] TextMeshProUGUI totalScoreText;

		protected override void Awake()
		{
			totalScoreText.text = "0";
		}

		public override void SetText<T>(T value)
		{
			SetTotalScoreText();        // 合計スコアのテキストも更新する

			// 桁区切り
			var intValue = Convert.ToInt32(value);
			var text = ScoreManager.GetScoreString(intValue * ScoreManager.ComboCount);

			uiObject.text = $"+{text}";
		}

		// 合計スコアのテキストの変更
		void SetTotalScoreText()
		{
			totalScoreText.text = ScoreManager.GetScoreString();
		}
	}
}