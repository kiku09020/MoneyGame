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
			SetTotalScoreText();        // ���v�X�R�A�̃e�L�X�g���X�V����

			// ����؂�
			var text = ScoreManager.GetScoreString((int)value * ScoreManager.ComboCount);

			return $"+{text}";
		}

		// ���v�X�R�A�̃e�L�X�g�̕ύX
		void SetTotalScoreText()
		{
			totalScoreText.text = ScoreManager.GetScoreString();
		}
	}
}