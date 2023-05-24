using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameController;
using GameController.UI.UIController;
using UnityEngine.Events;

namespace Game.Money.MoneyManager.Evaluator {
/// <summary>
/// �x�������̕]��������N���X
/// </summary>
/// 
	public class EvaluationManager : MonoBehaviour {
		#region Fields

		[SerializeField,Tooltip("�]�����X�g(�ォ�珇�Ɏ��s�����)")]
		List<Evaluator_Base> evalatorList = new List<Evaluator_Base>();

		[Header("TextControllers")]
		[SerializeField] AddedScoreTextController		scoreText;
		[SerializeField] AddedTimeTextController	timeText;
		[SerializeField] ComboTextController		comboText;

		#endregion

		//--------------------------------------------------

		private void Awake()
		{
			foreach(var eval in  evalatorList) {
				CheckType(eval);
			}
		}

		// ����A�~�X���ꂼ��ɃC�x���g�ǉ�
		void CheckType<T>(T eval) where T : Evaluator_Base
		{
			// ����]��
			if (eval is Evaluator_Correct correctEval) {
				eval.BasedEvalAction += () => Corrected(correctEval.AddedTime, correctEval.AddedScore);
			}

			// �~�X�]��
			else if (eval is Evaluator_Incorrect inCorrectEval) {
				eval.BasedEvalAction += () => Missed(inCorrectEval.RemovedTime);
			}
		}

		//--------------------------------------------------

		/// <summary>
		/// �]���`�F�b�N
		/// </summary>
		public void CheckEvaluators(WholeMoneyInfo info)
		{
			foreach(var unit in evalatorList) {
				// �]��
				if (unit.Evaluate(info)) {
					break;		// �]�������ɂ����Ă����甲����
				}
			}
		}

		//--------------------------------------------------

		// �~�X���̏���
		void Missed(float time)
		{
			GameTimeManager.RemoveTimer(time);						// �^�C�����Z
			ScoreManager.ResetCombo();								// �R���{���Z�b�g

			timeText.GenerateAndPlayAnimation(time);				// �^�C���e�L�X�g�����A�Đ�
			comboText.SetText(ScoreManager.ComboCount);		// �R���{�e�L�X�g�ύX
		}

		// �~�X�ȊO�̎��̏���
		void Corrected(float time, int score)
		{
			// �^�C���A�X�R�A�A�R���{���Z
			GameTimeManager.AddTimer(time);
			ScoreManager.AddCombo();
			ScoreManager.AddScore(score);

			// �e�L�X�g����
			timeText.GenerateAndPlayAnimation(time);
			scoreText.GenerateAndPlayAnimation(score);
			comboText.SetText(ScoreManager.ComboCount);         // �R���{�e�L�X�g�ύX
		}

		//--------------------------------------------------
	}
}