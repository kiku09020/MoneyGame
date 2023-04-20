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

	[Header("MoneyGroup")]
	[SerializeField] MoneyGroup paymentMG;

	//--------------------------------------------------

	/// <summary>
	/// 支払い可能かどうか(支払額が目標額よりも大きければ支払える)
	/// </summary>
	public bool CanPay => (paymentMG.MoneyAmount >= wholeMoneyInfo.TargetMoneyAmount) ? true : false;

	//--------------------------------------------------

	public class changeMoneyUnit {
		public readonly WholeMoneyInfo.MoneyUnit moneyUnit;
		public readonly int count;

		public changeMoneyUnit(WholeMoneyInfo.MoneyUnit money, int count)
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
			moneyGenerator.GenerateAndMoveChange(GetCharge());


			// おつりの金額から必要な小銭の枚数を求める
			// ミス判定の場合、タイムを減らす
		}
	}


	// おつりの枚数の取得
	List<changeMoneyUnit> GetCharge()
	{
		var changeMoneyList = new List<changeMoneyUnit>();		// おつりリスト
		var count = 0;      // おつりの数

		// おつり = 支払額 - 目標額
		var change = paymentMG.MoneyAmount - wholeMoneyInfo.TargetMoneyAmount;

		// 大きい方からチェック
		for (int i = wholeMoneyInfo.MoneyUnitList.Count -1; i >= 0; i--) {
			var moneyUnit = wholeMoneyInfo.MoneyUnitList[i];

			// おつりから各金額分引いた結果が0より大きい場合、数を追加
			while ((change - moneyUnit.Money.Data.Amount) >= 0) {
				change -= moneyUnit.Money.Data.Amount;
				count++;
			}

			// 0以下になった場合、おつりのリストに追加
			changeMoneyList.Add(new changeMoneyUnit(moneyUnit, count));     // リスト追加
			count = 0;                                                  // カウントリセット
		}

		return changeMoneyList;
	}

	// ミス判定
	bool CheckMiss()
	{
		var reached = false;    // 支払額が目標額に到達したかどうか

		var paidAmount = 0;     // 支払額

		foreach (var mgUnit in paymentMG.MoneyGroupUnitList) {
			foreach (var money in mgUnit.MoneyList) {

				// 到達していなければ加算
				if (!reached) {
					paidAmount += money.Data.Amount;        // 支払額に加算

					// 目標額よりも支払額が多くなったら、到達フラグ立てる
					if (wholeMoneyInfo.TargetMoneyAmount < paidAmount) {
						reached = true;
					}
				}

				// 到達したのに繰り返しが続く場合、余分に支払ったため、ミス判定とする
				else {
					return true;
				}
			}
		}

		return false;
	}
}
