using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class WholeMoneyCalculator : MonoBehaviour
{
	[Header("Components")]
    [SerializeField] WholeMoneyInfo wholeMoneyInfo;
	[SerializeField] MoneyGenerator moneyGenerator;

	[Header("Change")]
	[SerializeField] Transform targetTransform;

	//--------------------------------------------------

	/// <summary>
	/// 支払い可能かどうか(支払額が目標額よりも大きければ支払える)
	/// </summary>
	public bool CanPay => (wholeMoneyInfo.PaymentMG.MoneyAmount >= wholeMoneyInfo.TargetMoneyAmount) ? true : false;

	//--------------------------------------------------

	public class ChangeMoneyUnit {
		public readonly WholeMoneyInfo.MoneyUnit moneyUnit;
		public readonly int count;

		public ChangeMoneyUnit(WholeMoneyInfo.MoneyUnit money, int count)
		{
			this.moneyUnit = money;
			this.count = count;
		}
	}

	//--------------------------------------------------


	/// <summary>
	/// 支払い
	/// </summary>
	public void Payment()
	{
		if (CanPay) {
			// おつり生成して移動
			moneyGenerator.GenerateAndMoveChange(GetChangeMoneyList(), targetTransform);

			// 目標額transformに移動
			wholeMoneyInfo.PaymentMG.Mover.MoveToTargetTransform(targetTransform);

			// 目標額指定
			wholeMoneyInfo.SetTargetMoneyAmount();
		}
	}

	/// <summary>
	/// 支払い金額を手元に戻す
	/// </summary>
	public void Revert()
	{
		wholeMoneyInfo.PaymentMG.Mover.MoveToTarget(true, true, false);
	}

	//--------------------------------------------------

	// おつりの枚数の取得
	List<ChangeMoneyUnit> GetChangeMoneyList()
	{
		var changeMoneyList = new List<ChangeMoneyUnit>();		// おつりリスト
		var count = 0;      // おつりの数

		// おつり = 支払額 - 目標額
		var change = wholeMoneyInfo.PaymentMG.MoneyAmount - wholeMoneyInfo.TargetMoneyAmount;

		// 大きい方からチェック
		for (int i = wholeMoneyInfo.MoneyUnitList.Count -1; i >= 0; i--) {
			var moneyUnit = wholeMoneyInfo.MoneyUnitList[i];

			// おつりから各金額分引いた結果が0より大きい場合、数を追加
			while ((change - moneyUnit.Money.Data.Amount) >= 0) {
				change -= moneyUnit.Money.Data.Amount;
				count++;
			}

			// 0以下になった場合、おつりのリストに追加
			changeMoneyList.Add(new ChangeMoneyUnit(moneyUnit, count));     // リスト追加
			count = 0;                                                  // カウントリセット
		}

		return changeMoneyList;
	}


}
