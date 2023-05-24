using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

using GameController.UI.UIController;
using Game.Money.MoneyManager;
using Game.Goods.Mover;
using Game.Goods;
using UnityEngine.Events;

namespace GameController.UI.Button {
    public class PayButton : ActionButton {

		[Header("MoneyManagers")]
		[SerializeField] TargetPriceSetter priceSetter;

		[Header("EffectComponents")]
		[SerializeField] GoodsGenerator goodsGenerator;
		[SerializeField] GoodsMover goodsMover;

		[Header("Actions")]
		[SerializeField,Tooltip("�x�����ҋ@��̏���")] UnityEvent afterWaitingAction;

		[Header("Parameters")]
		[SerializeField, Tooltip("�x������̑ҋ@����")] float waitPaymentDuration = 1;

		// �x�����z���ڕW�z�����傫����΃N���b�N�\
		protected override bool Clickable => (moneyInfo.PaymentMG.MoneyAmount >= TargetPriceSetter.TargetPrice) ? true : false;

		//--------------------------------------------------

		CancellationToken token;

		private void Awake()
		{
			token = this.GetCancellationTokenOnDestroy();
		}

		//--------------------------------------------------

		protected override async void ClickedAction()
		{
			calculator.PaymentCoreAction();     // ��{�I�ȓ�����s

			SubActions();                       // �����֌W�̏����Ȃ�

			// �ҋ@
			await UniTask.Delay(TimeSpan.FromSeconds(waitPaymentDuration), false, PlayerLoopTiming.FixedUpdate, token);

			AfterWaitingAction();       // �ҋ@��̏���
		}

		protected override void CantClickAction()
		{

		}

		//--------------------------------------------------

		// �T�u�����Q
		void SubActions()
		{
			// ����̃e�L�X�g����

			// �x���z��ڕW�ztransform�Ɉړ�
			moneyInfo.PaymentMG.Mover.MoveToTargetTransform(calculator.TargetPriceTransform);

			// �����܂ňړ�
			goodsMover.MoveToBacketPoint(goodsGenerator.TargetGoods);

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