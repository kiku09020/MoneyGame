using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

using GameController.UI.TextController;
using Game.Money.MoneyManager;
using Game.Goods.Mover;
using Game.Goods;
using UnityEngine.Events;

namespace GameController.UI.Button {
    public class PayButton : MonoBehaviour {

		[Header("MoneyManagers")]
        [SerializeField] WholeMoneyCalculator calculator;
		[SerializeField] MoneyEvaluator evaluator;
		[SerializeField] WholeMoneyInfo moneyInfo;
		[SerializeField] TargetPriceSetter priceSetter;

		[Header("EffectComponents")]
		[SerializeField] ChangeTextController changeText;
		[SerializeField] GoodsGenerator goodsGenerator;
		[SerializeField] GoodsMover goodsMover;

		[Header("Actions")]
		[SerializeField] UnityEvent paymentAction;
		[SerializeField] UnityEvent afterWaitingAction;

		[Header("Parameters")]
		[SerializeField, Tooltip("�x������̑ҋ@����")] float waitPaymentDuration = 1;

		//--------------------------------------------------

		CancellationToken token;

		private void Awake()
		{
			token = this.GetCancellationTokenOnDestroy();
		}

		/// <summary>
		/// �{�^�������ꂽ��x������
		/// </summary>
		public async void OnPayment()
        {
			if (calculator.CanPay) {
				calculator.PaymentCoreAction();     // ��{�I�ȓ�����s

				SubActions();						// �����֌W�̏����Ȃ�

				// �ҋ@
				await UniTask.Delay(TimeSpan.FromSeconds(waitPaymentDuration), false, PlayerLoopTiming.FixedUpdate, token);

				AfterWaitingAction();		// �ҋ@��̏���
			}
		}

		// �T�u�����Q
		void SubActions()
		{
			// ����̃e�L�X�g����
			changeText.GenerateAndDispText(moneyInfo.Change);

			// �x���z��ڕW�ztransform�Ɉړ�
			moneyInfo.PaymentMG.Mover.MoveToTargetTransform(calculator.TargetPriceTransform);

			// �����܂ňړ�
			goodsMover.MoveToBacketPoint(goodsGenerator.CurrentGoods);

			paymentAction?.Invoke();				// ���̑��̏������s

			MainGameManager.isOperable = false;     // ����s��
		}

		// �ҋ@�㏈��
		void AfterWaitingAction()
		{
			MainGameManager.isOperable = true;		// ����\�ɖ߂�

			priceSetter.SetTargetMoneyAmount();     // �ڕW�z�w��

			afterWaitingAction?.Invoke();			// ���̑��̏������s

			goodsGenerator.GenerateGoods();			// ���i����
		}
    }
}