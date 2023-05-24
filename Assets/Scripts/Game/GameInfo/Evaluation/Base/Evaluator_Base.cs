using Cysharp.Threading.Tasks;
using GameController.UI.UIController;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Money.MoneyManager.Evaluator {
	/// <summary>
	/// �]�����N���X
	/// </summary>
	public abstract class Evaluator_Base : MonoBehaviour {
		[Header("Text")]
		[SerializeField, Tooltip("�e�L�X�g")] protected EvalTextController textController;

		[Header("Components")]
		[HideInInspector] public WholeMoneyInfo moneyInfo;

		//--------------------------------------------------

		/// <summary>
		/// �]�����ʂɊ�Â�������
		/// </summary>
		public event Action BasedEvalAction;

		/// <summary>
		/// �]���̏���
		/// </summary>
		protected abstract bool Condition(WholeMoneyInfo moneyInfo);

		/// <summary>
		/// �]�����̏���
		/// </summary>
		protected abstract void EvaluatedAction();

		/// <summary>
		/// �]��
		/// </summary>
		/// <returns>�]�����ꂽ���ǂ���</returns>
		public bool Evaluate(WholeMoneyInfo moneyInfo)
		{
			if (Condition(moneyInfo)) {
				EvaluatedAction();				// �]�����ꂽ�Ƃ��̏���

				BasedEvalAction?.Invoke();      // �]���Ɋ�Â������������s

				textController?.GenerateAndPlayAnimation();	// �e�L�X�g�̃A�j���[�V����

				return true;
			}
			

			return false;
		}
	}
}