using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.Money.MoneyManager {
using static WholeMoneyInfo;

	public class TargetPriceSetter : MonoBehaviour {
		[Header("TargetMoneyAmount")]
		[SerializeField, Tooltip("�ڕW�z�̎w��^�C�v")] PriceSetType priceSetType;
		[SerializeField, Tooltip("�ŏ��l")] int minTargetPrice = 200;
		[SerializeField, Tooltip("�ő�l")] int maxTargetPrice = 500;
		[SerializeField] float multiplicandMinValue = 2;
		[SerializeField, Tooltip("�ڕW�z�ɔ��f�����ő�R���{��")] int maxComboCount = 50;

		float currentMinValue;
		float currentMaxValue;

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

		private void OnGUI()
		{
			if (!Debug.isDebugBuild) return;

			GUI.color = Color.black;

			var guiStyle = new GUIStyle(GUI.skin.label);
			guiStyle.fontSize = 48;

			GUI.Label(new Rect(0, 0, 400, 200), $"({currentMinValue},{currentMaxValue})", guiStyle);
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
			var comboRate = ((float)(ScoreManager.ComboCount + 1) / (float)(maxComboCount + 1));        // �R���{��

			currentMinValue = minTargetPrice * (1 + comboRate * multiplicandMinValue);                  // �R���{�����猻�݂̍ŏ��l�Z�o
			currentMaxValue = currentMinValue + (maxTargetPrice * comboRate);                           // �R���{�����猻�݂̍ő�l�Z�o

			TargetPrice = (int)Random.Range(currentMinValue, currentMaxValue);                          // �ڕW�z�����_���w��
		}

		/// <summary>
		/// �ڕW�z�̎w��
		/// </summary>
		public void SetTargetMoneyAmount()
		{
			switch (priceSetType) {
				case PriceSetType.constant:         // �萔
					TargetPrice = 1111;
					break;

				case PriceSetType.random:           // ����
					TargetPrice = Random.Range(minTargetPrice, maxTargetPrice);
					break;

				case PriceSetType.randomWithCombo:  // �R���{��̗���
					RandomizePriceWithCombo();
					break;
			}

			// �ڕW�z�̃e�L�X�g�w��
			priceText.text = SeparatedAmountText(TargetPrice);
		}
	}
}