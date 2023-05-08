using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static WholeMoneyInfo;

public class TargetPriceSetter : MonoBehaviour
{
	[Header("TargetMoneyAmount")]
	[SerializeField, Tooltip("�ڕW�z�̎w��^�C�v")] PriceSetType priceSetType;
	[SerializeField,Tooltip("�ŏ��l")] int minTargetPrice = 200;
	[SerializeField,Tooltip("�ő�l")] int maxTargetPrice = 500;
	[SerializeField,Tooltip("�ڕW�z�ɔ��f�����ő�R���{��")] int maxComboCount = 50;

	[SerializeField] TextMeshProUGUI priceText;

	/// <summary>
	/// �ڕW�z
	/// </summary>
	public static int TargetPrice { get; private set; }

	//--------------------------------------------------

	private void Awake()
	{
		SetTargetMoneyAmount();                             // �ڕW�z�w��
	}

	/// <summary>
	/// �ڕW�z�͈͎̔w��
	/// </summary>
	public void SetTargetMoneyAmountRegion(int min, int max)
	{
		minTargetPrice = min;
		maxTargetPrice = max;
	}

	/// <summary>
	/// �R���{��̗���
	/// </summary>
	void RandomizePriceWithCombo()
	{
		var currentMinValue = minTargetPrice * (ScoreManager.ComboCount + 1);								// ���݂̍ŏ��l
		var currentMaxValue = minTargetPrice + maxTargetPrice * ((ScoreManager.ComboCount + 1) / (maxComboCount + 1));       // ���݂̍ő�l

		TargetPrice = Random.Range(currentMinValue, currentMaxValue);
	}

	/// <summary>
	/// �ڕW�z�̎w��
	/// </summary>
	public void SetTargetMoneyAmount()
	{
		switch (priceSetType) {
			case PriceSetType.constant:			// �萔
				TargetPrice = 1111;
				break;

			case PriceSetType.random:			// ����
				TargetPrice = Random.Range(minTargetPrice, maxTargetPrice);
				break;

			case PriceSetType.randomWithCombo:	// �R���{��̗���
				RandomizePriceWithCombo();
				break;
		}

		// �ڕW�z�̃e�L�X�g�w��
		priceText.text = SeparatedAmountText(TargetPrice);
	}
}
