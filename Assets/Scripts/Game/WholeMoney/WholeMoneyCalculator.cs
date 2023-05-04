using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class WholeMoneyCalculator : MonoBehaviour
{
	[Header("Components")]
    [SerializeField] WholeMoneyInfo wholeMoneyInfo;
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
	public bool CanPay => (wholeMoneyInfo.PaymentMG.MoneyAmount >= wholeMoneyInfo.TargetMoneyAmount) ? true : false;

	/// <summary>
	/// 支払い後の待機中かどうか
	/// </summary>
	public static bool IsWaitingPayment { get; private set; }

	//--------------------------------------------------

	public class ChangeMoneyUnit {
		public readonly WholeMoneyInfo.MoneyUnit moneyUnit;
		public readonly int count;

		public ChangeMoneyUnit(WholeMoneyInfo.MoneyUnit money, int count)
		{
			this.moneyUnit = money;
			this.count = count;
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
		if (CanPay) {
			// 評価
			evaluator.EvaluatePaidMoney();

			// おつりのテキスト生成
			changeTextController.GenerateAndDispText(wholeMoneyInfo.Change);

			// おつり生成して移動
			moneyGenerator.GenerateAndMoveChange(GetChangeMoneyList(), targetTransform);

			// 目標額transformに移動
			wholeMoneyInfo.PaymentMG.Mover.MoveToTargetTransform(targetTransform);

			// 札生成
			CheckBillCount();

			IsWaitingPayment = true;

			// 待機
			await UniTask.Delay(TimeSpan.FromSeconds(waitPaymentDuration), false, PlayerLoopTiming.FixedUpdate, token);

			IsWaitingPayment = false;

			// 目標額指定
			wholeMoneyInfo.SetTargetMoneyAmount();

		}
	}

	/// <summary>
	/// 支払い金額を手元に戻す
	/// </summary>
	public void Revert()
	{
		if (MainGameManager.isOperable) {
			wholeMoneyInfo.PaymentMG.Mover.MoveToTarget(true, true, false);
		}
	}

	//--------------------------------------------------

	// おつりの枚数の取得
	List<ChangeMoneyUnit> GetChangeMoneyList()
	{
		var changeMoneyList = new List<ChangeMoneyUnit>();		// おつりリスト
		var count = 0;      // おつりの数
		var _change = wholeMoneyInfo.PaymentMG.MoneyAmount - wholeMoneyInfo.TargetMoneyAmount;

		// 大きい方からチェック
		for (int i = wholeMoneyInfo.MoneyUnitList.Count -1; i >= 0; i--) {
			var moneyUnit = wholeMoneyInfo.MoneyUnitList[i];

			// おつりから各金額分引いた結果が0より大きい場合、数を追加
			while ((_change - moneyUnit.Money.Data.Amount) >= 0) {
				_change -= moneyUnit.Money.Data.Amount;
				count++;
			}

			// 0以下になった場合、おつりのリストに追加
			changeMoneyList.Add(new ChangeMoneyUnit(moneyUnit, count));     // リスト追加
			count = 0;                                                  // カウントリセット
		}

		return changeMoneyList;
	}

	void CheckBillCount()
	{
		// すくなくなったら、生成
		if (wholeMoneyInfo.PocketMG.MoneyGroupUnitList[6].MoneyList.Count < wholeMoneyInfo.MoneyUnitList[6].Money.Data.GeneratedCount) {
			moneyGenerator.GenerateAndMoveBill(wholeMoneyInfo.MoneyUnitList[6].PocketMG);
		}
	}
}
