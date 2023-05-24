using Cysharp.Threading.Tasks;
using GameController.UI.UIController;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Money.MoneyManager.Evaluator {
	/// <summary>
	/// 評価基底クラス
	/// </summary>
	public abstract class Evaluator_Base : MonoBehaviour {
		[Header("Text")]
		[SerializeField, Tooltip("テキスト")] protected EvalTextController textController;

		[Header("Components")]
		[HideInInspector] public WholeMoneyInfo moneyInfo;

		//--------------------------------------------------

		/// <summary>
		/// 評価結果に基づいた処理
		/// </summary>
		public event Action BasedEvalAction;

		/// <summary>
		/// 評価の条件
		/// </summary>
		protected abstract bool Condition(WholeMoneyInfo moneyInfo);

		/// <summary>
		/// 評価時の処理
		/// </summary>
		protected abstract void EvaluatedAction();

		/// <summary>
		/// 評価
		/// </summary>
		/// <returns>評価されたかどうか</returns>
		public bool Evaluate(WholeMoneyInfo moneyInfo)
		{
			if (Condition(moneyInfo)) {
				EvaluatedAction();				// 評価されたときの処理

				BasedEvalAction?.Invoke();      // 評価に基づいた処理を実行

				textController?.GenerateAndPlayAnimation();	// テキストのアニメーション

				return true;
			}
			

			return false;
		}
	}
}