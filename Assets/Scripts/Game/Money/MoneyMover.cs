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
	/// 支払いMoneyGroupに移動
	/// </summary>
	public void MoveToPaymentMG()
	{
		MoveBase(money.TargetPaymentMG, toPaymentMG);
	}

	/// <summary>
	/// プレイヤーのMoneyGroupに移動
	/// </summary>
	public void MoveToPlayerMG()
	{
		MoveBase(money.TargetPlayerMG, toPlayerMG);
	}

	// 基底メソッド
	void MoveBase(MoneyGroup moneyGroup, MovementParams moveParams)
	{
		transform.DOMove(moneyGroup.transform.position, moveParams.Duration)
			.OnComplete(() => {
				transform.SetParent(moneyGroup.transform);		// 親に指定
			});
	}
}
