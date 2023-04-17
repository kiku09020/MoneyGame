using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class MoneyMover : MonoBehaviour
{
	[Header("")]
	[SerializeField] Money money;

	[Header("Params")]
	[SerializeField] MovementParams toPaymentMG;
	[SerializeField] MovementParams toPlayerMG;

	//--------------------------------------------------

	[Serializable]
	class MovementParams
	{
		[SerializeField] float	duration;
		[SerializeField] Ease	easeType;

		public float Duration => duration;
	}


    //--------------------------------------------------

    void Awake()
    {
        
    }

	/// <summary>
	/// �x����MoneyGroup�Ɉړ�
	/// </summary>
	public void MoveToPaymentMG()
	{
		MoveBase(toPaymentMG, money.PlayerMG, money.PaymentMG);
	}

	/// <summary>
	/// �v���C���[��MoneyGroup�Ɉړ�
	/// </summary>
	public void MoveToPlayerMG()
	{
		MoveBase(toPlayerMG, money.PaymentMG, money.PlayerMG);
	}

	// ��ꃁ�\�b�h(�v�B)
	void MoveBase(MovementParams moveParams)
	{
		if (money.TargetMG == null) return;

		money.TargetMG.MoneyList.Add(money);                // �ړ����MG�̃��X�g�ɒǉ�
		money.CurrentMG.ChangeButtonAction(() => money.CurrentMG.TargetMoney?.Mover.MoveBase(moveParams));
		money.CurrentMG.MoneyList.Remove(money);            // ���݂�MG�̃��X�g���珜�O

		transform.DOMove(money.TargetMG.transform.position, moveParams.Duration)
			.OnComplete(() => {
				transform.SetParent(money.TargetMG.RectTransform);      // MG��e�Ɏw��
				money.ChangeCurrentMoneyGroup();					// money�̌��݂�MoneyGroup��ύX
			});
	}

	// ���ڌ��݂�MG�A�ڕW��MG���w�肷��(��)
	void MoveBase(MovementParams moveParams, MoneyGroupUnit current, MoneyGroupUnit target)
	{
		target.MoneyList.Add(money);
		current.ChangeButtonAction(() => current.TargetMoney?.Mover.MoveBase(moveParams, current, target));
		current.MoneyList.Remove(money);

		transform.DOMove(target.transform.position, moveParams.Duration)
			.OnComplete(() => {
				transform.SetParent(target.RectTransform);      // MG��e�Ɏw��
				money.ChangeCurrentMoneyGroup();                    // money�̌��݂�MoneyGroup��ύX
			});
	}
}
