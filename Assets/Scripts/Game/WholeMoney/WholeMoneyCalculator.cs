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
		[SerializeField] MoneyGenerator moneyGenerator;
		[SerializeField] EvaluationManager evaluator;

		[Header("Other")]
		[SerializeField] Transform targetPriceTransform;

		//--------------------------------------------------

		/// <summary>
		/// �ڕW�z��Transform
		/// </summary>
		public Transform TargetPriceTransform => targetPriceTransform;

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

		/// <summary>
		/// �x�����̕]���A���萶���Ȃǂ̊�b�I�ȏ���
		/// </summary>
		public void PaymentCoreAction()
		{
			var changeList = GetChangeMoneyList();

			// �]��
			evaluator.EvaluatePaidMoney();

			// ���萶�����Ĉړ�
			moneyGenerator.GenerateAndMoveChange(changeList, targetPriceTransform);

			// �D����
			CheckBillCount();
		}

		//--------------------------------------------------

		// ����̃��X�g���擾
		public List<ChangeMoneyUnit> GetChangeMoneyList()
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