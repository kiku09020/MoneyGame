using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static WholeMoneyInfo;

public class TargetPriceSetter : MonoBehaviour
{
	[Header("TargetMoneyAmount")]
	[SerializeField, Tooltip("目標額の指定タイプ")] PriceSetType priceSetType;
	[SerializeField,Tooltip("最小値")] int minTargetPrice = 200;
	[SerializeField,Tooltip("最大値")] int maxTargetPrice = 500;
	[SerializeField,Tooltip("目標額に反映される最大コンボ数")] int maxComboCount = 50;

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
		var currentMinValue = minTargetPrice * (ScoreManager.ComboCount + 1);								// 現在の最小値
		var currentMaxValue = minTargetPrice + maxTargetPrice * ((ScoreManager.ComboCount + 1) / (maxComboCount + 1));       // 現在の最大値

		TargetPrice = Random.Range(currentMinValue, currentMaxValue);
	}

	/// <summary>
	/// 目標額の指定
	/// </summary>
	public void SetTargetMoneyAmount()
	{
		switch (priceSetType) {
			case PriceSetType.constant:			// 定数
				TargetPrice = 1111;
				break;

			case PriceSetType.random:			// 乱数
				TargetPrice = Random.Range(minTargetPrice, maxTargetPrice);
				break;

			case PriceSetType.randomWithCombo:	// コンボ基準の乱数
				RandomizePriceWithCombo();
				break;
		}

		// 目標額のテキスト指定
		priceText.text = SeparatedAmountText(TargetPrice);
	}
}
