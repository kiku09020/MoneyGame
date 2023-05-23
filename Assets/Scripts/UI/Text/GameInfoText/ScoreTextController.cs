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

		public override void SetTextMessage(float value)
		{
			SetTotalScoreText();        // ���v�X�R�A�̃e�L�X�g���X�V����

			// ����؂�
			var text = ScoreManager.GetScoreString((int)value * ScoreManager.ComboCount);

			uiObject.text = $"+{text}";
		}

		// ���v�X�R�A�̃e�L�X�g�̕ύX
		void SetTotalScoreText()
		{
			totalScoreText.text = ScoreManager.GetScoreString();
		}
	}
}