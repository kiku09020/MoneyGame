using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameController;
using GameController.UI.TextController;

/// <summary>
/// 支払い時の評価をするクラス
/// </summary>
/// 
namespace Game.Money.MoneyManager {
	public class MoneyEvaluator : MonoBehaviour {
		#region Fields
		[Header("Parametars")]
		[SerializeField, Tooltip("ミス時の減算タイム")] float miss_RemovedTime = 10;
		[SerializeField, Tooltip("オーバー時の減算タイム")] float over_RemovedTime = 5;
		[SerializeField, Tooltip("パーフェクト時の加算タイム")] float parfectAddedTime = 10;
		[SerializeField, Tooltip("正常時の加算タイム")] float addedTime = 2;

		[Header("Evaluation")]
		[SerializeField] EvaluationManager evaluationManager;

		[Header("Components")]
		[SerializeField] WholeMoneyInfo wholeMoneyInfo;
		[SerializeField] ScoreTextController scoreText;
		[SerializeField] TimeTextController timeText;
		[SerializeField] EvaluateTextController evaluateText;
		[SerializeField] ComboTextController comboText;
		#endregion

		#region Properties
		/// <summary>
		/// 所持枚数が最大数よりも多いか
		/// </summary>
		bool IsOverPocketMoney => (wholeMoneyInfo.PocketMG.MoneyCount > wholeMoneyInfo.PocketMoneyMaxCount) ? true : false;

		/// <summary>
		/// パーフェクト判定。おつりが0円かどうか
		/// </summary>
		bool IsPerfect => (wholeMoneyInfo.Change == 0) ? true : false;
		#endregion

		//--------------------------------------------------

		/// <summary>
		/// 支払い金額を評価する
		/// </summary>
		/// <returns>評価した結果が、高評価(ミスをしていない)かどうか</returns>
		public bool EvaluatePaidMoney(List<WholeMoneyCalculator.ChangeMoneyUnit> changeList, int changeCount)
		{
			// ミス判定チェック
			if (CheckMiss(changeList)) {
				Missed(miss_RemovedTime);
				GenerateEvaluationText(EvaluationManager.EvaluationType.Missed);

				return false;
			}

			// 所持金枚数チェック
			if (CheckOver(changeCount)) {
				Missed(over_RemovedTime);
				GenerateEvaluationText(EvaluationManager.EvaluationType.Over);
				return false;
			}

			// パーフェクトチェック
			if (IsPerfect) {
				Corrected(parfectAddedTime, TargetPriceSetter.TargetPrice);
				GenerateEvaluationText(EvaluationManager.EvaluationType.Perfect);
				return true;
			}

			// 通常処理
			Corrected(addedTime, TargetPriceSetter.TargetPrice);
			GenerateEvaluationText(EvaluationManager.EvaluationType.Normal);
			return true;
		}

		//--------------------------------------------------

		/// <summary>
		/// 枚数越えを判定
		/// </summary>
		bool CheckOver(int changeCount)
		{
			if (changeCount + wholeMoneyInfo.PocketMG.MoneyCount > wholeMoneyInfo.PocketMoneyMaxCount) {
				return true;
			}

			return false;
		}

		//--------------------------------------------------

		/// <summary>
		/// ミス判定(旧版)
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
						if (TargetPriceSetter.TargetPrice < paidAmount) {
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

		/// <summary>
		/// おつりに支払ったお金が含まれていたらミス判定
		/// </summary>
		/// <param name="changeList"></param>
		/// <returns></returns>
		bool CheckMiss(List<WholeMoneyCalculator.ChangeMoneyUnit> changeList)
		{
			// 順序を反転
			changeList.Reverse();

			for (int i = 0; i < changeList.Count; i++) {
				if (changeList[i]?.MoneyList?.Count <= 0) continue;     // おつりの単位リストの数が少なければ、早期リターン

				if (changeList[i].MoneyList[0].Money == wholeMoneyInfo.PaymentMG.MoneyGroupUnitList[i].TargetMoney) {
					return true;
				}
			}

			return false;
		}

		//--------------------------------------------------

		// 評価テキスト生成
		void GenerateEvaluationText(EvaluationManager.EvaluationType evaluationType)
		{
			var evaluationUnit = evaluationManager.GetEvaluateMessage(evaluationType);

			evaluateText.GenerateAndDispText(evaluationUnit.Message, evaluationUnit.MessageColor);
		}

		// ミス時の処理
		void Missed(float removedTime)
		{
			GameTimeManager.RemoveTimer(removedTime);       // タイム減算
			ScoreManager.ResetCombo();                      // コンボリセット

			timeText.GenerateAndDispText(-removedTime);     // タイムテキスト生成
			comboText.SetText();                            // コンボテキスト変更
		}

		// ミス以外の時の処理
		void Corrected(float time, int score)
		{
			// タイム、スコア、コンボ加算
			GameTimeManager.AddTimer(time);
			ScoreManager.AddCombo();
			ScoreManager.AddScore(score);

			// テキスト生成
			timeText.GenerateAndDispText(time);
			scoreText.GenerateAndDispText(score);
			comboText.SetText();                            // コンボテキスト変更
		}
	}
}