using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WholeMoneyCalculator : MonoBehaviour
{
	[Header("Components")]
    [SerializeField] WholeMoneyInfo wholeMoneyInfo;
	[SerializeField] MoneyGenerator moneyGenerator;

	[Header("Change")]
	[SerializeField] Transform targetTransform;
	[SerializeField] TextMeshProUGUI changeText;

	[SerializeField] MovementParams moveParams;
	[SerializeField] float moveDistance;

	//--------------------------------------------------

	/// <summary>
	/// �x�����\���ǂ���(�x���z���ڕW�z�����傫����Ύx������)
	/// </summary>
	public bool CanPay => (wholeMoneyInfo.PaymentMG.MoneyAmount >= wholeMoneyInfo.TargetMoneyAmount) ? true : false;

	/// <summary>
	/// ����
	/// </summary>
	int Change => wholeMoneyInfo.PaymentMG.MoneyAmount - wholeMoneyInfo.TargetMoneyAmount;
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
			// ����̃e�L�X�g����
			GenerateChangeText();

			// ���萶�����Ĉړ�
			moneyGenerator.GenerateAndMoveChange(GetChangeMoneyList(), targetTransform);

			// �ڕW�ztransform�Ɉړ�
			wholeMoneyInfo.PaymentMG.Mover.MoveToTargetTransform(targetTransform);

			// �D����
			CheckBillCount();

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

	void GenerateChangeText()
	{

		var obj = Instantiate(changeText, transform);

		obj.text = $"+{Change.ToString()}";

		obj.rectTransform.DOAnchorPosY(moveDistance, moveParams.Duration)
			.SetEase(moveParams.EaseType)
			.OnComplete(() => {
				Destroy(obj.gameObject);
			});
	}
}
