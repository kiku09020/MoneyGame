using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �x�������̕]��������N���X
/// </summary>
/// 
public class MoneyEvaluator : MonoBehaviour
{
	#region Fields
	[Header("Parametars")]
	[SerializeField, Tooltip("�~�X���̌��Z�^�C��")]			float miss_RemovedTime = 10;
	[SerializeField, Tooltip("�I�[�o�[���̌��Z�^�C��")]		float over_RemovedTime =  5;
	[SerializeField, Tooltip("�p�[�t�F�N�g���̉��Z�^�C��")]	float parfectAddedTime = 10;
	[SerializeField, Tooltip("���펞�̉��Z�^�C��")]			float addedTime		   =  2;

	[Header("Evaluation")]
	[SerializeField] EvaluationManager evaluationManager;

	[Header("Components")]
    [SerializeField] WholeMoneyInfo wholeMoneyInfo;
	[SerializeField] ScoreTextController scoreText;
	[SerializeField] TimeTextController timeText;
	[SerializeField] EvaluateTextController evaluateText;
	[SerializeField] ComboTextController comboText;
	#endregion

	#region Properties
	/// <summary>
	/// �����������ő吔����������
	/// </summary>
	bool IsOverPocketMoney => (wholeMoneyInfo.PocketMG.MoneyCount > wholeMoneyInfo.PocketMoneyMaxCount) ? true : false;

	/// <summary>
	/// �p�[�t�F�N�g����B���肪0�~���ǂ���
	/// </summary>
	bool IsPerfect => (wholeMoneyInfo.Change == 0) ? true : false;
	#endregion

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
			GenerateEvaluationText(EvaluationManager.EvaluationType.Missed);
			
			return false;
		}

		// �����������`�F�b�N
		if(IsOverPocketMoney) {
			Missed(over_RemovedTime);
			GenerateEvaluationText(EvaluationManager.EvaluationType.Over);
			return false;
		}

		// �p�[�t�F�N�g�`�F�b�N
		if (IsPerfect) {
			Corrected(parfectAddedTime, wholeMoneyInfo.TargetMoneyAmount);
			GenerateEvaluationText(EvaluationManager.EvaluationType.Perfect);
			return true;
		}

		// �ʏ폈��
		Corrected(addedTime, wholeMoneyInfo.TargetMoneyAmount);
		GenerateEvaluationText(EvaluationManager.EvaluationType.Normal);
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

	// �]���e�L�X�g����
	void GenerateEvaluationText(EvaluationManager.EvaluationType evaluationType)
	{
		var evaluationUnit= evaluationManager.GetEvaluateMessage(evaluationType);

		evaluateText.GenerateAndDispText(evaluationUnit.Message, evaluationUnit.MessageColor);
	}

	// �~�X���̏���
	void Missed(float removedTime)
	{
		GameTimeManager.RemoveTimer(removedTime);		// �^�C�����Z
		ScoreManager.ResetCombo();						// �R���{���Z�b�g

		timeText.GenerateAndDispText(-removedTime);     // �^�C���e�L�X�g����
		comboText.SetText();							// �R���{�e�L�X�g�ύX
	}

	// �~�X�ȊO�̎��̏���
	void Corrected(float time,int score)
	{
		// �^�C���A�X�R�A�A�R���{���Z
		GameTimeManager.AddTimer(time);		
		ScoreManager.AddCombo();
		ScoreManager.AddScore(score);

		// �e�L�X�g����
		timeText.GenerateAndDispText(time);
		scoreText.GenerateAndDispText(score);
		comboText.SetText();							// �R���{�e�L�X�g�ύX
	}
}
