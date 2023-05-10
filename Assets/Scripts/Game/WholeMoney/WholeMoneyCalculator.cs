using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

using GameController;
using GameController.UI.TextController;

namespace Game.Money.MoneyManager {
	public class WholeMoneyCalculator : MonoBehaviour {
		[Header("Components")]
		[SerializeField] WholeMoneyInfo wholeMoneyInfo;
		[SerializeField] TargetPriceSetter priceSetter;
		[SerializeField] MoneyGenerator moneyGenerator;
		[SerializeField] MoneyEvaluator evaluator;
		[SerializeField] ChangeTextController changeTextController;

		[Header("Change")]
		[SerializeField] Transform targetTransform;

		[Header("Payment")]
		[SerializeField, Tooltip("支払い後の待機時間")] float waitPaymentDuration = 1;

		//--------------------------------------------------

		CancellationToken token;

		/// <summary>
		/// 支払い可能かどうか(支払額が目標額よりも大きければ支払える)
		/// </summary>
		public bool CanPay => (wholeMoneyInfo.PaymentMG.MoneyAmount >= TargetPriceSetter.TargetPrice) ? true : false;

		/// <summary>
		/// 支払い後の待機中かどうか
		/// </summary>
		public static bool IsWaitingPayment { get; private set; }

		//--------------------------------------------------

		public class ChangeMoneyUnit {
			List<WholeMoneyInfo.MoneyUnit> moneyList = new List<WholeMoneyInfo.MoneyUnit>();

			public List<WholeMoneyInfo.MoneyUnit> MoneyList => moneyList;

			public ChangeMoneyUnit(List<WholeMoneyInfo.MoneyUnit> moneyList)
			{
				this.moneyList = moneyList;
			}
		}

		//--------------------------------------------------


		private void Awake()
		{
			token = this.GetCancellationTokenOnDestroy();

			IsWaitingPayment = false;
		}

		/// <summary>
		/// 支払い
		/// </summary>
		public async void Payment()
		{
			if (CanPay && !IsWaitingPayment) {
				var changeList = GetChangeMoneyList();

				// 評価
				evaluator.EvaluatePaidMoney(changeList, GetChangeCount());

				// おつりのテキスト生成
				changeTextController.GenerateAndDispText(wholeMoneyInfo.Change);

				// おつり生成して移動
				moneyGenerator.GenerateAndMoveChange(changeList, targetTransform);

				// 目標額transformに移動
				wholeMoneyInfo.PaymentMG.Mover.MoveToTargetTransform(targetTransform);

				// 札生成
				CheckBillCount();

				// SetFlags
				IsWaitingPayment = true;                    // 待機中
				MainGameManager.isOperable = false;         // 操作不可

				// 待機
				await UniTask.Delay(TimeSpan.FromSeconds(waitPaymentDuration), false, PlayerLoopTiming.FixedUpdate, token);

				// ResetFlags
				IsWaitingPayment = false;
				MainGameManager.isOperable = true;

				// 目標額指定
				priceSetter.SetTargetMoneyAmount();

			}
		}

		/// <summary>
		/// 支払い金額を手元に戻す
		/// </summary>
		public void Revert()
		{
			if (MainGameManager.isOperable && !IsWaitingPayment) {
				wholeMoneyInfo.PaymentMG.Mover.MoveToTarget(true, true, false);
			}
		}

		//--------------------------------------------------

		// おつりのリストを取得
		List<ChangeMoneyUnit> GetChangeMoneyList()
		{
			var changeMoneyList = new List<ChangeMoneyUnit>();                  // おつりリスト
			var _change = wholeMoneyInfo.Change;                                // おつりから差し引きされる値

			// 大きい方からチェック
			for (int i = wholeMoneyInfo.MoneyUnitList.Count - 1; i >= 0; i--) {
				var moneyUnitList = new List<WholeMoneyInfo.MoneyUnit>();       // おつりの単位ごとのリスト
				var moneyUnit = wholeMoneyInfo.MoneyUnitList[i];                // おつりの単位

				// おつりから各単位の金額分引いた結果が0より大きい場合
				// おつりの単位リストに追加
				while ((_change - moneyUnit.Money.Data.Amount) >= 0) {
					_change -= moneyUnit.Money.Data.Amount;                     // おつりから差し引く
					moneyUnitList.Add(moneyUnit);                               // 追加
				}

				// 0以下になった場合、おつりのリストに追加
				changeMoneyList.Add(new ChangeMoneyUnit(moneyUnitList));        // 単位リストをおつりリストに追加
			}

			return changeMoneyList;
		}

		// おつりの枚数を取得
		public int GetChangeCount()
		{
			var list = GetChangeMoneyList();
			var count = 0;

			foreach (var changeUnit in list) {
				count += changeUnit.MoneyList.Count;
			}

			return count;
		}

		// お札の数を確認して、少ない場合に生成する
		async void CheckBillCount()
		{
			var pocketBillCount = wholeMoneyInfo.PocketMG.MoneyGroupUnitList[6].MoneyList.Count;        // 所持金のお札の数
			var startBillCount = wholeMoneyInfo.MoneyUnitList[6].Money.Data.GeneratedCount;         // お札の初期枚数

			// すくなくなったら、その分生成
			if (pocketBillCount < startBillCount) {
				var targetCount = startBillCount - pocketBillCount;

				for (int i = 0; i < targetCount; i++) {
					await moneyGenerator.GenerateAndMoveBill(wholeMoneyInfo.MoneyUnitList[6].PocketMG);
				}
			}
		}
	}
}