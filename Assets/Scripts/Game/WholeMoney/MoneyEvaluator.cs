using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameController;
using GameController.UI.TextController;

/// <summary>
/// �x�������̕]��������N���X
/// </summary>
/// 
namespace Game.Money.MoneyManager {
	public class MoneyEvaluator : MonoBehaviour {
		#region Fields
		[Header("Parametars")]
		[SerializeField, Tooltip("�~�X���̌��Z�^�C��")]			float miss_RemovedTime	= 10;
		[SerializeField, Tooltip("�I�[�o�[���̌��Z�^�C��")]		float over_RemovedTime	=  5;
		[SerializeField, Tooltip("�p�[�t�F�N�g���̉��Z�^�C��")] float parfectAddedTime	= 10;
		[SerializeField, Tooltip("���펞�̉��Z�^�C��")]			float addedTime			=  2;

		[Header("Components")]
		[SerializeField] EvaluationManager evaluationManager;
		[SerializeField] WholeMoneyInfo wholeMoneyInfo;

		[Header("TextControllers")]
		[SerializeField] ScoreTextController scoreText;
		[SerializeField] AddedTimeTextController timeText;
		[SerializeField] EvaluateTextController evaluateText;
		[SerializeField] ComboTextController comboText;
		#endregion

		#region Properties
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
		public bool EvaluatePaidMoney(List<WholeMoneyCalculator.ChangeMoneyUnit> changeList, int changeCount)
		{
			// �~�X����`�F�b�N
			if (CheckMiss(changeList)) {
				Missed(miss_RemovedTime);												// �~�X����
				GenerateEvaluationText(EvaluationManager.EvaluationType.Missed);		// �e�L�X�g����
				return false;
			}

			// �����������`�F�b�N
			if (CheckOver(changeCount)) {
				Missed(over_RemovedTime);												// �~�X����
				GenerateEvaluationText(EvaluationManager.EvaluationType.Over);			// �e�L�X�g����
				return false;
			}

			// �p�[�t�F�N�g�`�F�b�N
			if (IsPerfect) {
				Corrected(parfectAddedTime, TargetPriceSetter.TargetPrice);				// ��������
				GenerateEvaluationText(EvaluationManager.EvaluationType.Perfect);		// �e�L�X�g����
				return true;
			}

			// �ʏ폈��
			Corrected(addedTime, TargetPriceSetter.TargetPrice);						// ��������
			GenerateEvaluationText(EvaluationManager.EvaluationType.Normal);			// �e�L�X�g����
			return true;
		}

		//--------------------------------------------------

		/// <summary>
		/// �����z���𔻒�
		/// </summary>
		bool CheckOver(int changeCount)
		{
			// ���薇�� + �����������ő及�������𒴂�����Atrue����
			if (changeCount + wholeMoneyInfo.PocketMG.MoneyCount > wholeMoneyInfo.PocketMoneyMaxCount) {
				return true;
			}

			return false;
		}

		//--------------------------------------------------

		/// <summary>
		/// ����Ɏx�������������܂܂�Ă�����~�X����
		/// </summary>
		/// <param name="changeList"></param>
		/// <returns></returns>
		bool CheckMiss(List<WholeMoneyCalculator.ChangeMoneyUnit> changeList)
		{
			changeList.Reverse();										// ����̃��X�g�̏����𔽓]

			for (int i = 0; i < changeList.Count; i++) {
				if (changeList[i]?.MoneyList?.Count <= 0) continue;     // ����̒P�ʃ��X�g�̐������Ȃ���΁A���̒P�ʂ�

				// �܂܂�Ă�����true
				if (changeList[i].MoneyList[0].Money == wholeMoneyInfo.PaymentMG.MoneyGroupUnitList[i].TargetMoney) {
					return true;
				}
			}

			return false;
		}

		//--------------------------------------------------

		// �]���e�L�X�g����
		void GenerateEvaluationText(EvaluationManager.EvaluationType evaluationType)
		{
			var evaluationUnit = evaluationManager.GetEvaluateMessage(evaluationType);

			evaluateText.GenerateAndDispText(evaluationUnit.Message, evaluationUnit.MessageColor);
		}

		// �~�X���̏���
		void Missed(float removedTime)
		{
			GameTimeManager.RemoveTimer(removedTime);       // �^�C�����Z
			ScoreManager.ResetCombo();                      // �R���{���Z�b�g

			timeText.GenerateAndDispText(-removedTime);     // �^�C���e�L�X�g����
			comboText.SetText();                            // �R���{�e�L�X�g�ύX
		}

		// �~�X�ȊO�̎��̏���
		void Corrected(float time, int score)
		{
			// �^�C���A�X�R�A�A�R���{���Z
			GameTimeManager.AddTimer(time);
			ScoreManager.AddCombo();
			ScoreManager.AddScore(score);

			// �e�L�X�g����
			timeText.GenerateAndDispText(time);
			scoreText.GenerateAndDispText(score);
			comboText.SetText();                            // �R���{�e�L�X�g�ύX
		}
	}
}