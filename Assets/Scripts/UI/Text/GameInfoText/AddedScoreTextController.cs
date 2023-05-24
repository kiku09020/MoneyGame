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
			SetTotalScoreText();        // ���v�X�R�A�̃e�L�X�g���X�V����

			// ����؂�
			var intValue = Convert.ToInt32(value);
			var text = ScoreManager.GetScoreString(intValue * ScoreManager.ComboCount);

			uiObject.text = $"+{text}";
		}

		// ���v�X�R�A�̃e�L�X�g�̕ύX
		void SetTotalScoreText()
		{
			totalScoreText.text = ScoreManager.GetScoreString();
		}
	}
}