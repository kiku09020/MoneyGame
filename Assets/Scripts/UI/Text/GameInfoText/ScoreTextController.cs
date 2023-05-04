using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextController : TextController_Generatable
{
	[SerializeField] TextMeshProUGUI totalScoreText;

	private void Awake()
	{
		totalScoreText.text = "0";
	}

	protected override string SetMessage(object value)
	{
		SetTotalScoreText();        // ���v�X�R�A�̃e�L�X�g���X�V����

		// ����؂�
		var text = string.Format("{0:#,0}", (int)value * ScoreManager.Combo);

		return $"+{text}";
	}

	// ���v�X�R�A�̃e�L�X�g�̕ύX
	void SetTotalScoreText()
	{
		var scoreText = string.Format("{0:#,0}", ScoreManager.Score);

		totalScoreText.text = scoreText;
	}
}
