using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 支払い時の評価をするクラス
/// </summary>
/// 
public class MoneyEvaluation : MonoBehaviour
{
    [SerializeField] WholeMoneyInfo wholeMoneyInfo;

	/// <summary>
	/// 所持枚数が最大数よりも多いか
	/// </summary>
	public bool IsOverPocketMoney => (wholeMoneyInfo.PocketMG.MoneyAmount > wholeMoneyInfo.PocketMoneyMaxCount) ? true : false;

    //--------------------------------------------------

	/// <summary>
	/// ミス判定
	/// </summary>
	public bool CheckMiss()
	{
		var reached = false;    // 支払額が目標額に到達したかどうか

		var paidAmount = 0;     // 支払額

		foreach (var mgUnit in wholeMoneyInfo.PaymentMG.MoneyGroupUnitList) {
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
