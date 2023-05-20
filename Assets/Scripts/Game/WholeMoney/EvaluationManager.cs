using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameController;
using GameController.UI.TextController;
using UnityEngine.Events;

namespace Game.Money.MoneyManager {
/// <summary>
/// �x�������̕]��������N���X
/// </summary>
/// 
	public class EvaluationManager : MonoBehaviour {
		#region Fields

		[SerializeField,Tooltip("�]�����X�g(�ォ�珇�Ɏ��s�����)")]
		List<Evaluator_Base> evaluationUnitList = new List<Evaluator_Base>();

		[Header("Components")]
		[SerializeField] WholeMoneyInfo		wholeMoneyInfo;

		[Header("TextControllers")]
		[SerializeField] ScoreTextController		scoreText;
		[SerializeField] AddedTimeTextController	timeText;
		[SerializeField] ComboTextController		comboText;

		#endregion

		//--------------------------------------------------

		private void Awake()
		{
			// �emoneyInfo�K�p
			if (evaluationUnitList.Count != 0) {

				foreach (var unit in evaluationUnitList) {
					unit.moneyInfo = wholeMoneyInfo;		// moneyInfo�K�p

					// �~�X�A���폈�������ꂼ��ǉ�
					if (unit.IsCorrect) {
						unit.EvaluateSubEvent += () => Corrected(unit.TargetTime, TargetPriceSetter.TargetPrice);
					}

					else {
						unit.EvaluateSubEvent += () => Missed(unit.TargetTime);
					}
				}
			}
		}

		/// <summary>
		/// �x�������z��]������
		/// </summary>
		public void EvaluatePaidMoney()
		{
			foreach(var unit in evaluationUnitList) {

				// �]��
				if (unit.Evaluate()) {
					break;		// �]�������ɂ����Ă����甲����
				}
			}
		}

		//--------------------------------------------------

		// �~�X���̏���
		void Missed(float time)
		{
			GameTimeManager.AddTimer(time);			// �^�C�����Z
			ScoreManager.ResetCombo();              // �R���{���Z�b�g

			timeText.GenerateAndPlayAllAnimation(time);
			comboText.SetText();                    // �R���{�e�L�X�g�ύX
		}

		// �~�X�ȊO�̎��̏���
		void Corrected(float time, int score)
		{
			// �^�C���A�X�R�A�A�R���{���Z
			GameTimeManager.AddTimer(time);
			ScoreManager.AddCombo();
			ScoreManager.AddScore(score);

			// �e�L�X�g����
			timeText.GenerateAndPlayAllAnimation(time);
			scoreText.GenerateAndPlayAllAnimation(score);
			comboText.SetText();                            // �R���{�e�L�X�g�ύX
		}

		//--------------------------------------------------

		Evaluator_Base GetEvaluationUnit<T>() where T : Evaluator_Base
		{
			foreach (var evalUnit in evaluationUnitList) {
				if (evalUnit.GetType() is T) {
					return evalUnit;
				}
			}

			return null;
		}
	}
}