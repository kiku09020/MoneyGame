using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameController;
using GameController.UI.UIController;
using UnityEngine.Events;

namespace Game.Money.MoneyManager.Evaluator {
/// <summary>
/// 支払い時の評価をするクラス
/// </summary>
/// 
	public class EvaluationManager : MonoBehaviour {
		#region Fields

		[SerializeField,Tooltip("評価リスト(上から順に実行される)")]
		List<Evaluator_Base> evalatorList = new List<Evaluator_Base>();

		[Header("TextControllers")]
		[SerializeField] AddedScoreTextController		scoreText;
		[SerializeField] AddedTimeTextController	timeText;
		[SerializeField] ComboTextController		comboText;

		#endregion

		//--------------------------------------------------

		private void Awake()
		{
			foreach(var eval in  evalatorList) {
				CheckType(eval);
			}
		}

		// 正常、ミスそれぞれにイベント追加
		void CheckType<T>(T eval) where T : Evaluator_Base
		{
			// 正常評価
			if (eval is Evaluator_Correct correctEval) {
				eval.BasedEvalAction += () => Corrected(correctEval.AddedTime, correctEval.AddedScore);
			}

			// ミス評価
			else if (eval is Evaluator_Incorrect inCorrectEval) {
				eval.BasedEvalAction += () => Missed(inCorrectEval.RemovedTime);
			}
		}

		//--------------------------------------------------

		/// <summary>
		/// 評価チェック
		/// </summary>
		public void CheckEvaluators(WholeMoneyInfo info)
		{
			foreach(var unit in evalatorList) {
				// 評価
				if (unit.Evaluate(info)) {
					break;		// 評価条件にあっていたら抜ける
				}
			}
		}

		//--------------------------------------------------

		// ミス時の処理
		void Missed(float time)
		{
			GameTimeManager.RemoveTimer(time);						// タイム減算
			ScoreManager.ResetCombo();								// コンボリセット

			timeText.GenerateAndPlayAnimation(time);				// タイムテキスト生成、再生
			comboText.SetText(ScoreManager.ComboCount);		// コンボテキスト変更
		}

		// ミス以外の時の処理
		void Corrected(float time, int score)
		{
			// タイム、スコア、コンボ加算
			GameTimeManager.AddTimer(time);
			ScoreManager.AddCombo();
			ScoreManager.AddScore(score);

			// テキスト生成
			timeText.GenerateAndPlayAnimation(time);
			scoreText.GenerateAndPlayAnimation(score);
			comboText.SetText(ScoreManager.ComboCount);         // コンボテキスト変更
		}

		//--------------------------------------------------
	}
}