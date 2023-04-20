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

	[Header("Change")]
	[SerializeField] Transform targetTransform;

	//--------------------------------------------------

	/// <summary>
	/// �x�����\���ǂ���(�x���z���ڕW�z�����傫����Ύx������)
	/// </summary>
	public bool CanPay => (wholeMoneyInfo.PaymentMG.MoneyAmount >= wholeMoneyInfo.TargetMoneyAmount) ? true : false;

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


	/// <summary>
	/// �x����
	/// </summary>
	public void Payment()
	{
		if (CanPay) {
			// ���萶�����Ĉړ�
			moneyGenerator.GenerateAndMoveChange(GetChangeMoneyList(), targetTransform);

			// �ڕW�ztransform�Ɉړ�
			wholeMoneyInfo.PaymentMG.Mover.MoveToTargetTransform(targetTransform);

			// �ڕW�z�w��
			wholeMoneyInfo.SetTargetMoneyAmount();
		}
	}

	/// <summary>
	/// �x�������z���茳�ɖ߂�
	/// </summary>
	public void Revert()
	{
		wholeMoneyInfo.PaymentMG.Mover.MoveToTarget(true, true, false);
	}

	//--------------------------------------------------

	// ����̖����̎擾
	List<ChangeMoneyUnit> GetChangeMoneyList()
	{
		var changeMoneyList = new List<ChangeMoneyUnit>();		// ���胊�X�g
		var count = 0;      // ����̐�

		// ���� = �x���z - �ڕW�z
		var change = wholeMoneyInfo.PaymentMG.MoneyAmount - wholeMoneyInfo.TargetMoneyAmount;

		// �傫��������`�F�b�N
		for (int i = wholeMoneyInfo.MoneyUnitList.Count -1; i >= 0; i--) {
			var moneyUnit = wholeMoneyInfo.MoneyUnitList[i];

			// ���肩��e���z�����������ʂ�0���傫���ꍇ�A����ǉ�
			while ((change - moneyUnit.Money.Data.Amount) >= 0) {
				change -= moneyUnit.Money.Data.Amount;
				count++;
			}

			// 0�ȉ��ɂȂ����ꍇ�A����̃��X�g�ɒǉ�
			changeMoneyList.Add(new ChangeMoneyUnit(moneyUnit, count));     // ���X�g�ǉ�
			count = 0;                                                  // �J�E���g���Z�b�g
		}

		return changeMoneyList;
	}


}
