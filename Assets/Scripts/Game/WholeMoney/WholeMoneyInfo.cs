using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class WholeMoneyInfo : SimpleSingleton<WholeMoneyInfo> {
	[Header("PocketMoneyCount")]
	[SerializeField, Tooltip("最初のお金の最大枚数")] int startPocketMoneyMaxCount;

	[Header("TargetMoneyAmount")]
	[SerializeField, Tooltip("目標額の指定タイプ")] TargetMoneyType targetMoneyType;
	[SerializeField] int minTargetMoneyAmount = 200;
	[SerializeField] int maxTargetMoneyAmount = 500;

	[SerializeField] TextMeshProUGUI targetMoneyAmountText;



	[Header("MoneyList")]
	[SerializeField] List<MoneyUnit> moneyUnitList = new List<MoneyUnit>();

	//--------------------------------------------------

	[System.Serializable]
	public class MoneyUnit {
		public string name;
		[SerializeField] Money money;

		[Header("MoneyGroups")]
		[SerializeField, Tooltip("目標の所持金グループ")] MoneyGroupUnit targetPocketMG;
		[SerializeField, Tooltip("目標の支払いグループ")] MoneyGroupUnit targetPaymentMG;

		public Money Money => money;
		public MoneyGroupUnit PocketMG => targetPocketMG;
		public MoneyGroupUnit PaymentMG => targetPaymentMG;
	}

	//--------------------------------------------------

	// 目標額のタイプ
	public enum TargetMoneyType {
		constant,               // 定数
		random,                 // ランダム値
		randomWithScore,        // スコアに応じた範囲内のランダム値
	}

	public List<MoneyUnit> MoneyUnitList => moneyUnitList;

	/// <summary>
	/// 所持金の最大枚数
	/// </summary>
	public int PocketMoneyMaxCount { get; private set; }

	/// <summary>
	/// 目標額
	/// </summary>
	public int TargetMoneyAmount { get; private set; }

	//--------------------------------------------------

	protected override void Awake()
	{
		base.Awake();

		PocketMoneyMaxCount = startPocketMoneyMaxCount;

		SetTargetMoneyAmount();
	}

	/// <summary>
	/// 目標額の範囲指定
	/// </summary>
	public void SetTargetMoneyAmountRegion(int min, int max)
	{
		minTargetMoneyAmount = min;
		maxTargetMoneyAmount = max;
	}

	//--------------------------------------------------

	/// <summary>
	/// 目標額の指定
	/// </summary>
	public void SetTargetMoneyAmount()
	{
		switch (targetMoneyType) {
			case TargetMoneyType.constant:
				TargetMoneyAmount = 1111;
				break;

			case TargetMoneyType.random:
				TargetMoneyAmount = Random.Range(minTargetMoneyAmount, maxTargetMoneyAmount);
				break;
		}

		targetMoneyAmountText.text = SeparatedAmountText(TargetMoneyAmount);
	}

	//--------------------------------------------------

	/// <summary>
	/// 桁区切りした金額の文字列を作成する
	/// </summary>
	public static string SeparatedAmountText(int amount)
	{
		var amountText = string.Format("{0:#,0}", amount);
		return $"¥{amountText}";
	}
}
