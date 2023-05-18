using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameController;
using GameController.UI.TextController;
using UnityEngine.Events;

namespace Game.Money.MoneyManager {
/// <summary>
/// 支払い時の評価をするクラス
/// </summary>
/// 
	public class EvaluationManager : MonoBehaviour {
		#region Fields

		[SerializeField,Tooltip("評価リスト(上から順に実行される)")]
		List<Evaluator_Base> evaluationUnitList = new List<Evaluator_Base>();

		[Header("Components")]
		[SerializeField] WholeMoneyInfo		wholeMoneyInfo;

		[Header("TextControllers")]
		[SerializeField] ScoreTextController		scoreText;
		[SerializeField] AddedTimeTextController	timeText;
		[SerializeField] ComboTextController		comboText;

		#endregion

		//--------------------------------------------------

		private void Awake()
		{
			// 各moneyInfo適用
			if (evaluationUnitList.Count != 0) {

				foreach (var unit in evaluationUnitList) {
					unit.moneyInfo = wholeMoneyInfo;		// moneyInfo適用

					// ミス、正常処理をそれぞれ追加
					if (unit.IsCorrect) {
						unit.EvaluateSubEvent += () => Corrected(unit.TargetTime, TargetPriceSetter.TargetPrice);
					}

					else {
						unit.EvaluateSubEvent += () => Missed(unit.TargetTime);
					}
				}
			}
		}

		/// <summary>
		/// 支払い金額を評価する
		/// </summary>
		public void EvaluatePaidMoney()
		{
			foreach(var unit in evaluationUnitList) {

				// 評価
				if (unit.Evaluate()) {
					break;		// 評価条件にあっていたら抜ける
				}
			}
		}

		//--------------------------------------------------

		// ミス時の処理
		void Missed(float time)
		{
			GameTimeManager.AddTimer(time);			// タイム減算
			ScoreManager.ResetCombo();              // コンボリセット

			timeText.GenerateAndPlayAllAnimation(time);
			comboText.SetText();                    // コンボテキスト変更
		}

		// ミス以外の時の処理
		void Corrected(float time, int score)
		{
			// タイム、スコア、コンボ加算
			GameTimeManager.AddTimer(time);
			ScoreManager.AddCombo();
			ScoreManager.AddScore(score);

			// テキスト生成
			timeText.GenerateAndPlayAllAnimation(time);
			scoreText.GenerateAndPlayAllAnimation(score);
			comboText.SetText();                            // コンボテキスト変更
		}

		//--------------------------------------------------

		Evaluator_Base GetEvaluationUnit<T>() where T : Evaluator_Base
		{
			foreach (var evalUnit in evaluationUnitList) {
				if (evalUnit.GetType() is T) {
					return evalUnit;
				}
			}

			return null;
		}
	}
}