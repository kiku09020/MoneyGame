using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

using GameController.UI.TextController;
using Game.Money.MoneyManager;
using Game.Goods.Mover;
using Game.Goods;
using UnityEngine.Events;

namespace GameController.UI.Button {
    public class PayButton : MonoBehaviour {

		[Header("MoneyManagers")]
        [SerializeField] WholeMoneyCalculator calculator;
		[SerializeField] MoneyEvaluator evaluator;
		[SerializeField] WholeMoneyInfo moneyInfo;
		[SerializeField] TargetPriceSetter priceSetter;

		[Header("EffectComponents")]
		[SerializeField] ChangeTextController changeText;
		[SerializeField] GoodsGenerator goodsGenerator;
		[SerializeField] GoodsMover goodsMover;

		[Header("Actions")]
		[SerializeField] UnityEvent paymentAction;
		[SerializeField] UnityEvent afterWaitingAction;

		[Header("Parameters")]
		[SerializeField, Tooltip("支払い後の待機時間")] float waitPaymentDuration = 1;

		//--------------------------------------------------

		CancellationToken token;

		private void Awake()
		{
			token = this.GetCancellationTokenOnDestroy();
		}

		/// <summary>
		/// ボタン押されたら支払処理
		/// </summary>
		public async void OnPayment()
        {
			if (calculator.CanPay) {
				calculator.PaymentCoreAction();     // 基本的な動作実行

				SubActions();						// 装飾関係の処理など

				// 待機
				await UniTask.Delay(TimeSpan.FromSeconds(waitPaymentDuration), false, PlayerLoopTiming.FixedUpdate, token);

				AfterWaitingAction();		// 待機後の処理
			}
		}

		// サブ処理群
		void SubActions()
		{
			// おつりのテキスト生成
			changeText.GenerateAndDispText(moneyInfo.Change);

			// 支払額を目標額transformに移動
			moneyInfo.PaymentMG.Mover.MoveToTargetTransform(calculator.TargetPriceTransform);

			// かごまで移動
			goodsMover.MoveToBacketPoint(goodsGenerator.CurrentGoods);

			paymentAction?.Invoke();				// その他の処理実行

			MainGameManager.isOperable = false;     // 操作不可
		}

		// 待機後処理
		void AfterWaitingAction()
		{
			MainGameManager.isOperable = true;		// 操作可能に戻す

			priceSetter.SetTargetMoneyAmount();     // 目標額指定

			afterWaitingAction?.Invoke();			// その他の処理実行

			goodsGenerator.GenerateGoods();			// 商品生成
		}
    }
}