using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.Money.MoneyManager {
using static WholeMoneyInfo;

	public class TargetPriceSetter : MonoBehaviour {
		[Header("TargetMoneyAmount")]
		[SerializeField, Tooltip("目標額の指定タイプ")] PriceSetType priceSetType;
		[SerializeField, Tooltip("最小値")] int minTargetPrice = 200;
		[SerializeField, Tooltip("最大値")] int maxTargetPrice = 500;
		[SerializeField] float multiplicandMinValue = 2;
		[SerializeField, Tooltip("目標額に反映される最大コンボ数")] int maxComboCount = 50;

		float currentMinValue;
		float currentMaxValue;

		[SerializeField] TextMeshProUGUI priceText;

		/// <summary>
		/// 目標額
		/// </summary>
		public static int TargetPrice { get; private set; }

		//--------------------------------------------------

		private void Awake()
		{
			SetTargetMoneyAmount();                             // 目標額指定
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
		/// 目標額の範囲指定
		/// </summary>
		public void SetTargetMoneyAmountRegion(int min, int max)
		{
			minTargetPrice = min;
			maxTargetPrice = max;
		}

		/// <summary>
		/// コンボ基準の乱数
		/// </summary>
		void RandomizePriceWithCombo()
		{
			var comboRate = ((float)(ScoreManager.ComboCount + 1) / (float)(maxComboCount + 1));        // コンボ率

			currentMinValue = minTargetPrice * (1 + comboRate * multiplicandMinValue);                  // コンボ率から現在の最小値算出
			currentMaxValue = currentMinValue + (maxTargetPrice * comboRate);                           // コンボ率から現在の最大値算出

			TargetPrice = (int)Random.Range(currentMinValue, currentMaxValue);                          // 目標額ランダム指定
		}

		/// <summary>
		/// 目標額の指定
		/// </summary>
		public void SetTargetMoneyAmount()
		{
			switch (priceSetType) {
				case PriceSetType.constant:         // 定数
					TargetPrice = 1111;
					break;

				case PriceSetType.random:           // 乱数
					TargetPrice = Random.Range(minTargetPrice, maxTargetPrice);
					break;

				case PriceSetType.randomWithCombo:  // コンボ基準の乱数
					RandomizePriceWithCombo();
					break;
			}

			// 目標額のテキスト指定
			priceText.text = SeparatedAmountText(TargetPrice);
		}
	}
}