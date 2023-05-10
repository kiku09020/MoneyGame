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
		[SerializeField, Tooltip("�x������̑ҋ@����")] float waitPaymentDuration = 1;

		//--------------------------------------------------

		CancellationToken token;

		/// <summary>
		/// �x�����\���ǂ���(�x���z���ڕW�z�����傫����Ύx������)
		/// </summary>
		public bool CanPay => (wholeMoneyInfo.PaymentMG.MoneyAmount >= TargetPriceSetter.TargetPrice) ? true : false;

		/// <summary>
		/// �x������̑ҋ@�����ǂ���
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
		/// �x����
		/// </summary>
		public async void Payment()
		{
			if (CanPay && !IsWaitingPayment) {
				var changeList = GetChangeMoneyList();

				// �]��
				evaluator.EvaluatePaidMoney(changeList, GetChangeCount());

				// ����̃e�L�X�g����
				changeTextController.GenerateAndDispText(wholeMoneyInfo.Change);

				// ���萶�����Ĉړ�
				moneyGenerator.GenerateAndMoveChange(changeList, targetTransform);

				// �ڕW�ztransform�Ɉړ�
				wholeMoneyInfo.PaymentMG.Mover.MoveToTargetTransform(targetTransform);

				// �D����
				CheckBillCount();

				// SetFlags
				IsWaitingPayment = true;                    // �ҋ@��
				MainGameManager.isOperable = false;         // ����s��

				// �ҋ@
				await UniTask.Delay(TimeSpan.FromSeconds(waitPaymentDuration), false, PlayerLoopTiming.FixedUpdate, token);

				// ResetFlags
				IsWaitingPayment = false;
				MainGameManager.isOperable = true;

				// �ڕW�z�w��
				priceSetter.SetTargetMoneyAmount();

			}
		}

		/// <summary>
		/// �x�������z���茳�ɖ߂�
		/// </summary>
		public void Revert()
		{
			if (MainGameManager.isOperable && !IsWaitingPayment) {
				wholeMoneyInfo.PaymentMG.Mover.MoveToTarget(true, true, false);
			}
		}

		//--------------------------------------------------

		// ����̃��X�g���擾
		List<ChangeMoneyUnit> GetChangeMoneyList()
		{
			var changeMoneyList = new List<ChangeMoneyUnit>();                  // ���胊�X�g
			var _change = wholeMoneyInfo.Change;                                // ���肩�獷�����������l

			// �傫��������`�F�b�N
			for (int i = wholeMoneyInfo.MoneyUnitList.Count - 1; i >= 0; i--) {
				var moneyUnitList = new List<WholeMoneyInfo.MoneyUnit>();       // ����̒P�ʂ��Ƃ̃��X�g
				var moneyUnit = wholeMoneyInfo.MoneyUnitList[i];                // ����̒P��

				// ���肩��e�P�ʂ̋��z�����������ʂ�0���傫���ꍇ
				// ����̒P�ʃ��X�g�ɒǉ�
				while ((_change - moneyUnit.Money.Data.Amount) >= 0) {
					_change -= moneyUnit.Money.Data.Amount;                     // ���肩�獷������
					moneyUnitList.Add(moneyUnit);                               // �ǉ�
				}

				// 0�ȉ��ɂȂ����ꍇ�A����̃��X�g�ɒǉ�
				changeMoneyList.Add(new ChangeMoneyUnit(moneyUnitList));        // �P�ʃ��X�g�����胊�X�g�ɒǉ�
			}

			return changeMoneyList;
		}

		// ����̖������擾
		public int GetChangeCount()
		{
			var list = GetChangeMoneyList();
			var count = 0;

			foreach (var changeUnit in list) {
				count += changeUnit.MoneyList.Count;
			}

			return count;
		}

		// ���D�̐����m�F���āA���Ȃ��ꍇ�ɐ�������
		async void CheckBillCount()
		{
			var pocketBillCount = wholeMoneyInfo.PocketMG.MoneyGroupUnitList[6].MoneyList.Count;        // �������̂��D�̐�
			var startBillCount = wholeMoneyInfo.MoneyUnitList[6].Money.Data.GeneratedCount;         // ���D�̏�������

			// �����Ȃ��Ȃ�����A���̕�����
			if (pocketBillCount < startBillCount) {
				var targetCount = startBillCount - pocketBillCount;

				for (int i = 0; i < targetCount; i++) {
					await moneyGenerator.GenerateAndMoveBill(wholeMoneyInfo.MoneyUnitList[6].PocketMG);
				}
			}
		}
	}
}