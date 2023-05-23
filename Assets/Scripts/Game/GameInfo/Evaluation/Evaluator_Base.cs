using Cysharp.Threading.Tasks;
using GameController.UI.TextController;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Money.MoneyManager {
	public abstract class Evaluator_Base : MonoBehaviour {
		[Header("Text")]
		[SerializeField, Tooltip("テキスト")] protected GameController.UI.TextController.TextController_Base textController;

		[Header("Parameter")]
		[SerializeField,Tooltip("ミス判定やオーバー判定じゃないか")]	protected bool isCorrect;
		[SerializeField,Tooltip("タイマーに追加・減算するタイム")]		protected float targetTime;
		[SerializeField,Tooltip("待機時間")] protected float waitTime; 

		[Header("SubEvents")]
		[SerializeField, Tooltip("サブイベント")] UnityEvent subEvent;

		[Header("Components")]
		[HideInInspector] public WholeMoneyInfo moneyInfo;

		CancellationToken token;

		//--------------------------------------------------
		// Properties
		public bool IsCorrect => isCorrect;

		public float TargetTime => targetTime;

		//--------------------------------------------------

		private void Awake()
		{
			token = this.GetCancellationTokenOnDestroy();
		}

		//--------------------------------------------------

		/// <summary>
		/// サブイベント。スクリプトから追加したい場合に利用する
		/// </summary>
		public Action EvaluateSubEvent;

		/// <summary>
		/// 評価の条件
		/// </summary>
		protected abstract bool Condition();

		/// <summary>
		/// サブアクション
		/// </summary>
		//protected abstract void SubAction();

		/// <summary>
		/// 評価
		/// </summary>
		/// <returns>評価されたかどうか</returns>
		public bool Evaluate()
		{
			if (Condition()) {
				CommonAction();     // 実行

				// サブイベント群を実行
				EvaluateSubEvent?.Invoke();
				subEvent?.Invoke();

				return true;
			}

			return false;
		}

		//--------------------------------------------------

		/// <summary>
		/// 共通処理
		/// </summary>
		async void CommonAction()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(waitTime), cancellationToken: token);		// 待機

			textController.PlayAllAnimations();
		}
	}
}