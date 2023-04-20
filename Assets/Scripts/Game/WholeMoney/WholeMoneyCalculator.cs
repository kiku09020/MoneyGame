using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class WholeMoneyCalculator : MonoBehaviour
{
	[Header("Components")]
    [SerializeField] WholeMoneyInfo wholeMoneyInfo;
	[SerializeField] MoneyGenerator moneyGenerator;

	[Header("MoneyGroup")]
	[SerializeField] MoneyGroup paymentMG;

	[Header("Change")]
	[SerializeField] Transform targetTransform;

	//--------------------------------------------------

	/// <summary>
	/// �x�����\���ǂ���(�x���z���ڕW�z�����傫����Ύx������)
	/// </summary>
	public bool CanPay => (paymentMG.MoneyAmount >= wholeMoneyInfo.TargetMoneyAmount) ? true : false;

	//--------------------------------------------------

	public class changeMoneyUnit {
		public readonly WholeMoneyInfo.MoneyUnit moneyUnit;
		public readonly int count;

		public changeMoneyUnit(WholeMoneyInfo.MoneyUnit money, int count)
		{
			this.moneyUnit = money;
			this.count = count;
		}
	}

	//--------------------------------------------------


	/// <summary>
	/// �x����
	/// </summary>
	public void Payment()
	{
		if (CanPay) {
			// ���萶�����Ĉړ�
			moneyGenerator.GenerateAndMoveChange(GetCharge(), targetTransform);

			// �ڕW�ztransform�Ɉړ�
			paymentMG.Mover.MoveToTargetTransform(targetTransform);


		}
	}

	/// <summary>
	/// �x�������z���茳�ɖ߂�
	/// </summary>
	public void Revert()
	{
		paymentMG.Mover.MoveToTarget(true, true, false);
	}

	//--------------------------------------------------

	// ����̖����̎擾
	List<changeMoneyUnit> GetCharge()
	{
		var changeMoneyList = new List<changeMoneyUnit>();		// ���胊�X�g
		var count = 0;      // ����̐�

		// ���� = �x���z - �ڕW�z
		var change = paymentMG.MoneyAmount - wholeMoneyInfo.TargetMoneyAmount;

		// �傫��������`�F�b�N
		for (int i = wholeMoneyInfo.MoneyUnitList.Count -1; i >= 0; i--) {
			var moneyUnit = wholeMoneyInfo.MoneyUnitList[i];

			// ���肩��e���z�����������ʂ�0���傫���ꍇ�A����ǉ�
			while ((change - moneyUnit.Money.Data.Amount) >= 0) {
				change -= moneyUnit.Money.Data.Amount;
				count++;
			}

			// 0�ȉ��ɂȂ����ꍇ�A����̃��X�g�ɒǉ�
			changeMoneyList.Add(new changeMoneyUnit(moneyUnit, count));     // ���X�g�ǉ�
			count = 0;                                                  // �J�E���g���Z�b�g
		}

		return changeMoneyList;
	}

	// �~�X����
	bool CheckMiss()
	{
		var reached = false;    // �x���z���ڕW�z�ɓ��B�������ǂ���

		var paidAmount = 0;     // �x���z

		foreach (var mgUnit in paymentMG.MoneyGroupUnitList) {
			foreach (var money in mgUnit.MoneyList) {

				// ���B���Ă��Ȃ���Ή��Z
				if (!reached) {
					paidAmount += money.Data.Amount;        // �x���z�ɉ��Z

					// �ڕW�z�����x���z�������Ȃ�����A���B�t���O���Ă�
					if (wholeMoneyInfo.TargetMoneyAmount < paidAmount) {
						reached = true;
					}
				}

				// ���B�����̂ɌJ��Ԃ��������ꍇ�A�]���Ɏx���������߁A�~�X����Ƃ���
				else {
					return true;
				}
			}
		}

		return false;
	}
}
