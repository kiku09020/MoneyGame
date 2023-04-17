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
		MoveBase(toPaymentMG);
	}

	/// <summary>
	/// �v���C���[��MoneyGroup�Ɉړ�
	/// </summary>
	public void MoveToPlayerMG()
	{
		MoveBase(toPlayerMG);
	}

	// ��ꃁ�\�b�h
	void MoveBase(MovementParams moveParams)
	{
		transform.DOMove(money.TargetMG.transform.position, moveParams.Duration)
			.OnComplete(() => {

				money.TargetMG.MoneyList.Add(money);                // �ړ����MG�̃��X�g�ɒǉ�
				money.CurrentMG.ChangeButtonAction(() => money.CurrentMG.TargetMoney?.Mover.MoveBase(moveParams));
				money.CurrentMG.MoneyList.Remove(money);			// ���݂�MG�̃��X�g���珜�O

				transform.SetParent(money.TargetMG.RectTransform);      // MG��e�Ɏw��

				money.ChangeCurrentMoneyGroup();					// money�̌��݂�MoneyGroup��ύX
			});
	}
}
