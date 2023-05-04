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
	[SerializeField, Tooltip("�x������̑ҋ@����")] float waitPaymentDuration = 1;

	//--------------------------------------------------

	CancellationToken token;

	/// <summary>
	/// �x�����\���ǂ���(�x���z���ڕW�z�����傫����Ύx������)
	/// </summary>
	public bool CanPay => (wholeMoneyInfo.PaymentMG.MoneyAmount >= wholeMoneyInfo.TargetMoneyAmount) ? true : false;

	/// <summary>
	/// �x������̑ҋ@�����ǂ���
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
	/// �x����
	/// </summary>
	public async void Payment()
	{
		if (CanPay) {
			// �]��
			evaluator.EvaluatePaidMoney();

			// ����̃e�L�X�g����
			changeTextController.GenerateAndDispText(wholeMoneyInfo.Change);

			// ���萶�����Ĉړ�
			moneyGenerator.GenerateAndMoveChange(GetChangeMoneyList(), targetTransform);

			// �ڕW�ztransform�Ɉړ�
			wholeMoneyInfo.PaymentMG.Mover.MoveToTargetTransform(targetTransform);

			// �D����
			CheckBillCount();

			IsWaitingPayment = true;

			// �ҋ@
			await UniTask.Delay(TimeSpan.FromSeconds(waitPaymentDuration), false, PlayerLoopTiming.FixedUpdate, token);

			IsWaitingPayment = false;

			// �ڕW�z�w��
			wholeMoneyInfo.SetTargetMoneyAmount();

		}
	}

	/// <summary>
	/// �x�������z���茳�ɖ߂�
	/// </summary>
	public void Revert()
	{
		if (MainGameManager.isOperable) {
			wholeMoneyInfo.PaymentMG.Mover.MoveToTarget(true, true, false);
		}
	}

	//--------------------------------------------------

	// ����̖����̎擾
	List<ChangeMoneyUnit> GetChangeMoneyList()
	{
		var changeMoneyList = new List<ChangeMoneyUnit>();		// ���胊�X�g
		var count = 0;      // ����̐�
		var _change = wholeMoneyInfo.PaymentMG.MoneyAmount - wholeMoneyInfo.TargetMoneyAmount;

		// �傫��������`�F�b�N
		for (int i = wholeMoneyInfo.MoneyUnitList.Count -1; i >= 0; i--) {
			var moneyUnit = wholeMoneyInfo.MoneyUnitList[i];

			// ���肩��e���z�����������ʂ�0���傫���ꍇ�A����ǉ�
			while ((_change - moneyUnit.Money.Data.Amount) >= 0) {
				_change -= moneyUnit.Money.Data.Amount;
				count++;
			}

			// 0�ȉ��ɂȂ����ꍇ�A����̃��X�g�ɒǉ�
			changeMoneyList.Add(new ChangeMoneyUnit(moneyUnit, count));     // ���X�g�ǉ�
			count = 0;                                                  // �J�E���g���Z�b�g
		}

		return changeMoneyList;
	}

	void CheckBillCount()
	{
		// �����Ȃ��Ȃ�����A����
		if (wholeMoneyInfo.PocketMG.MoneyGroupUnitList[6].MoneyList.Count < wholeMoneyInfo.MoneyUnitList[6].Money.Data.GeneratedCount) {
			moneyGenerator.GenerateAndMoveBill(wholeMoneyInfo.MoneyUnitList[6].PocketMG);
		}
	}
}
