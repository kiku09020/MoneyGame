using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �x�������̕]��������N���X
/// </summary>
/// 
public class MoneyEvaluator : MonoBehaviour
{
	[Header("Parametars")]
	[SerializeField, Tooltip("�~�X���̌��Z�^�C��")]			float miss_RemovedTime = 10;
	[SerializeField, Tooltip("�I�[�o�[���̌��Z�^�C��")]		float over_RemovedTime =  5;
	[SerializeField, Tooltip("�p�[�t�F�N�g���̉��Z�^�C��")]	float parfectAddedTime = 10;
	[SerializeField, Tooltip("���펞�̉��Z�^�C��")]			float addedTime		   =  2;

	[Header("Components")]
    [SerializeField] WholeMoneyInfo wholeMoneyInfo;

	// Properties
	/// <summary>
	/// �����������ő吔����������
	/// </summary>
	bool IsOverPocketMoney => (wholeMoneyInfo.PocketMG.MoneyAmount > wholeMoneyInfo.PocketMoneyMaxCount) ? true : false;

	/// <summary>
	/// �p�[�t�F�N�g����B���肪0�~���ǂ���
	/// </summary>
	bool IsPerfect => (wholeMoneyInfo.Change == 0) ? true : false;

    //--------------------------------------------------

	/// <summary>
	/// �x�������z��]������
	/// </summary>
	/// <returns>�]���������ʂ��A���]��(�~�X�����Ă��Ȃ�)���ǂ���</returns>
	public bool EvaluatePaidMoney()
	{
		// �~�X����`�F�b�N
		if (CheckMiss()) {
			Missed(miss_RemovedTime);
			return false;
		}

		// �����������`�F�b�N
		if(IsOverPocketMoney) {
			Missed(over_RemovedTime);
			return false;
		}

		// �p�[�t�F�N�g�`�F�b�N
		if (IsPerfect) {
			Corrected(parfectAddedTime, wholeMoneyInfo.TargetMoneyAmount);
			return true;
		}

		// �ʏ폈��
		Corrected(addedTime, wholeMoneyInfo.TargetMoneyAmount);
		return true;
	}

	//--------------------------------------------------

	/// <summary>
	/// �~�X����
	/// </summary>
	bool CheckMiss()
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

	//--------------------------------------------------

	// �~�X���̏���
	void Missed(float removedTime)
	{
		GameTimeManager.RemoveTimer(removedTime);		// �^�C�����Z
		ScoreManager.ResetCombo();				// �R���{���Z�b�g
	}

	// �~�X�ȊO�̎��̏���
	void Corrected(float time,int score)
	{
		// �^�C���A�X�R�A�A�R���{���Z
		GameTimeManager.AddTimer(time);		
		ScoreManager.AddScore(score);
		ScoreManager.AddCombo();
	}
}
