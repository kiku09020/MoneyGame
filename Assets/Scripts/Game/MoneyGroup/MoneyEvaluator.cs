using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 支払い時の評価をするクラス
/// </summary>
/// 
public class MoneyEvaluator : MonoBehaviour
{
	[Header("Parametars")]
	[SerializeField, Tooltip("ミス時の減算タイム")]			float miss_RemovedTime = 10;
	[SerializeField, Tooltip("オーバー時の減算タイム")]		float over_RemovedTime =  5;
	[SerializeField, Tooltip("パーフェクト時の加算タイム")]	float parfectAddedTime = 10;
	[SerializeField, Tooltip("正常時の加算タイム")]			float addedTime		   =  2;

	[Header("Components")]
    [SerializeField] WholeMoneyInfo wholeMoneyInfo;

	// Properties
	/// <summary>
	/// 所持枚数が最大数よりも多いか
	/// </summary>
	bool IsOverPocketMoney => (wholeMoneyInfo.PocketMG.MoneyAmount > wholeMoneyInfo.PocketMoneyMaxCount) ? true : false;

	/// <summary>
	/// パーフェクト判定。おつりが0円かどうか
	/// </summary>
	bool IsPerfect => (wholeMoneyInfo.Change == 0) ? true : false;

    //--------------------------------------------------

	/// <summary>
	/// 支払い金額を評価する
	/// </summary>
	/// <returns>評価した結果が、高評価(ミスをしていない)かどうか</returns>
	public bool EvaluatePaidMoney()
	{
		// ミス判定チェック
		if (CheckMiss()) {
			Missed(miss_RemovedTime);
			return false;
		}

		// 所持金枚数チェック
		if(IsOverPocketMoney) {
			Missed(over_RemovedTime);
			return false;
		}

		// パーフェクトチェック
		if (IsPerfect) {
			Corrected(parfectAddedTime, wholeMoneyInfo.TargetMoneyAmount);
			return true;
		}

		// 通常処理
		Corrected(addedTime, wholeMoneyInfo.TargetMoneyAmount);
		return true;
	}

	//--------------------------------------------------

	/// <summary>
	/// ミス判定
	/// </summary>
	bool CheckMiss()
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

	//--------------------------------------------------

	// ミス時の処理
	void Missed(float removedTime)
	{
		GameTimeManager.RemoveTimer(removedTime);		// タイム減算
		ScoreManager.ResetCombo();				// コンボリセット
	}

	// ミス以外の時の処理
	void Corrected(float time,int score)
	{
		// タイム、スコア、コンボ加算
		GameTimeManager.AddTimer(time);		
		ScoreManager.AddScore(score);
		ScoreManager.AddCombo();
	}
}
