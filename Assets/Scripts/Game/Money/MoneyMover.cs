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
		MoveBase(money.TargetPaymentMG, toPaymentMG);
	}

	/// <summary>
	/// �v���C���[��MoneyGroup�Ɉړ�
	/// </summary>
	public void MoveToPlayerMG()
	{
		MoveBase(money.TargetPlayerMG, toPlayerMG);
	}

	// ��ꃁ�\�b�h
	void MoveBase(MoneyGroup moneyGroup, MovementParams moveParams)
	{
		transform.DOMove(moneyGroup.transform.position, moveParams.Duration)
			.OnComplete(() => {
				transform.SetParent(moneyGroup.transform);		// �e�Ɏw��
			});
	}
}
