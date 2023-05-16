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
    public class PayButton : ActionButton {

		[Header("MoneyManagers")]
		[SerializeField] MoneyEvaluator evaluator;
		[SerializeField] TargetPriceSetter priceSetter;

		[Header("EffectComponents")]
		[SerializeField] ChangeTextController changeText;
		[SerializeField] GoodsGenerator goodsGenerator;
		[SerializeField] GoodsMover goodsMover;

		[Header("Actions")]
		[SerializeField,Tooltip("支払い待機後の処理")] UnityEvent afterWaitingAction;

		[Header("Parameters")]
		[SerializeField, Tooltip("支払い後の待機時間")] float waitPaymentDuration = 1;

		// 支払金額の枚数が0枚だったらクリック可能
		protected override bool Clickable => (moneyInfo.PaymentMG.MoneyCount != 0) ? true : false;

		//--------------------------------------------------

		CancellationToken token;

		private void Awake()
		{
			token = this.GetCancellationTokenOnDestroy();
		}

		//--------------------------------------------------

		protected override async void ClickedAction()
		{
			calculator.PaymentCoreAction();     // 基本的な動作実行

			SubActions();                       // 装飾関係の処理など

			// 待機
			await UniTask.Delay(TimeSpan.FromSeconds(waitPaymentDuration), false, PlayerLoopTiming.FixedUpdate, token);

			AfterWaitingAction();       // 待機後の処理
		}

		protected override void CantClickAction()
		{

		}

		//--------------------------------------------------

		// サブ処理群
		void SubActions()
		{
			// おつりのテキスト生成
			changeText.GenerateAndDispText(moneyInfo.Change);

			// 支払額を目標額transformに移動
			moneyInfo.PaymentMG.Mover.MoveToTargetTransform(calculator.TargetPriceTransform);

			// かごまで移動
			goodsMover.MoveToBacketPoint(goodsGenerator.TargetGoods);

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