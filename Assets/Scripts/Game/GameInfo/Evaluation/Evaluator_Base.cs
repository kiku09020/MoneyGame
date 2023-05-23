using Cysharp.Threading.Tasks;
using GameController.UI.TextController;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Money.MoneyManager {
	public abstract class Evaluator_Base : MonoBehaviour {
		[Header("Text")]
		[SerializeField, Tooltip("�e�L�X�g")] protected GameController.UI.TextController.TextController_Base textController;

		[Header("Parameter")]
		[SerializeField,Tooltip("�~�X�����I�[�o�[���肶��Ȃ���")]	protected bool isCorrect;
		[SerializeField,Tooltip("�^�C�}�[�ɒǉ��E���Z����^�C��")]		protected float targetTime;
		[SerializeField,Tooltip("�ҋ@����")] protected float waitTime; 

		[Header("SubEvents")]
		[SerializeField, Tooltip("�T�u�C�x���g")] UnityEvent subEvent;

		[Header("Components")]
		[HideInInspector] public WholeMoneyInfo moneyInfo;

		CancellationToken token;

		//--------------------------------------------------
		// Properties
		public bool IsCorrect => isCorrect;

		public float TargetTime => targetTime;

		//--------------------------------------------------

		private void Awake()
		{
			token = this.GetCancellationTokenOnDestroy();
		}

		//--------------------------------------------------

		/// <summary>
		/// �T�u�C�x���g�B�X�N���v�g����ǉ��������ꍇ�ɗ��p����
		/// </summary>
		public Action EvaluateSubEvent;

		/// <summary>
		/// �]���̏���
		/// </summary>
		protected abstract bool Condition();

		/// <summary>
		/// �T�u�A�N�V����
		/// </summary>
		//protected abstract void SubAction();

		/// <summary>
		/// �]��
		/// </summary>
		/// <returns>�]�����ꂽ���ǂ���</returns>
		public bool Evaluate()
		{
			if (Condition()) {
				CommonAction();     // ���s

				// �T�u�C�x���g�Q�����s
				EvaluateSubEvent?.Invoke();
				subEvent?.Invoke();

				return true;
			}

			return false;
		}

		//--------------------------------------------------

		/// <summary>
		/// ���ʏ���
		/// </summary>
		async void CommonAction()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(waitTime), cancellationToken: token);		// �ҋ@

			textController.PlayAllAnimations();
		}
	}
}