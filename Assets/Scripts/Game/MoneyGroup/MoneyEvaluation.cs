using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �x�������̕]��������N���X
/// </summary>
/// 
public class MoneyEvaluation : MonoBehaviour
{
    [SerializeField] WholeMoneyInfo wholeMoneyInfo;

	/// <summary>
	/// �����������ő吔����������
	/// </summary>
	public bool IsOverPocketMoney => (wholeMoneyInfo.PocketMG.MoneyAmount > wholeMoneyInfo.PocketMoneyMaxCount) ? true : false;

    //--------------------------------------------------

	/// <summary>
	/// �~�X����
	/// </summary>
	public bool CheckMiss()
	{
		var reached = false;    // �x���z���ڕW�z�ɓ��B�������ǂ���

		var paidAmount = 0;     // �x���z

		foreach (var mgUnit in wholeMoneyInfo.PaymentMG.MoneyGroupUnitList) {
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
