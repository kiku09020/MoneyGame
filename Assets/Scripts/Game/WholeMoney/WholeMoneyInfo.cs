using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MG = Game.Money.MoneyGroup;

namespace Game.Money.MoneyManager {
	public class WholeMoneyInfo : SimpleSingleton<WholeMoneyInfo> {

		#region Fields
		[Header("PocketMoneyCount")]
		[SerializeField, Tooltip("最初のお金の最大枚数")] int startPocketMoneyMaxCount;

		[Header("Money")]
		[SerializeField] MG.MoneyGroup paymentMG;
		[SerializeField] MG.MoneyGroup pocketMG;

		[SerializeField, Tooltip("お金に加えて、MoneyGroupを指定したクラスのリスト")]
		List<MoneyUnit> moneyUnitList = new List<MoneyUnit>();

		#endregion

		//--------------------------------------------------

		#region Classes

		[System.Serializable]
		public class MoneyUnit {
			public string name;
			[SerializeField] Money money;

			[Header("MoneyGroups")]
			[SerializeField, Tooltip("目標の所持金グループ")] MG.MoneyGroupUnit targetPocketMG;
			[SerializeField, Tooltip("目標の支払いグループ")] MG.MoneyGroupUnit targetPaymentMG;

			public Money Money => money;
			public MG.MoneyGroupUnit PocketMG => targetPocketMG;
			public MG.MoneyGroupUnit PaymentMG => targetPaymentMG;
		}

		#endregion

		//--------------------------------------------------

		#region Properties
		/// <summary>
		/// お金に加えて、MoneyGroupを指定したクラスのリスト
		/// </summary>
		public List<MoneyUnit> MoneyUnitList => moneyUnitList;

		/// <summary>
		/// 所持金の最大枚数
		/// </summary>
		public int PocketMoneyMaxCount { get; private set; }

		/// <summary>
		/// 支払いMoneyGroup
		/// </summary>
		public MG.MoneyGroup PaymentMG => paymentMG;
		/// <summary>
		/// 所持金MoneyGroup
		/// </summary>
		public MG.MoneyGroup PocketMG => pocketMG;

		/// <summary>
		/// おつり
		/// </summary>
		public int Change => paymentMG.MoneyAmount - TargetPriceSetter.TargetPrice;
		#endregion

		/// <summary>
		/// 目標額のタイプ
		/// </summary>
		public enum PriceSetType {
			constant,               // 定数
			random,                 // ランダム値
			randomWithCombo,        // コンボに応じた範囲内のランダム値
		}

		//--------------------------------------------------

		protected override void Awake()
		{
			base.Awake();

			PocketMoneyMaxCount = startPocketMoneyMaxCount;     // 所持金の最大枚数を指定
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
}