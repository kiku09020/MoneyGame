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
		MoveBase(toPaymentMG, money.PlayerMG, money.PaymentMG);
	}

	/// <summary>
	/// プレイヤーのMoneyGroupに移動
	/// </summary>
	public void MoveToPlayerMG()
	{
		MoveBase(toPlayerMG, money.PaymentMG, money.PlayerMG);
	}

	// 基底メソッド(没。)
	void MoveBase(MovementParams moveParams)
	{
		if (money.TargetMG == null) return;

		money.TargetMG.MoneyList.Add(money);                // 移動先のMGのリストに追加
		money.CurrentMG.ChangeButtonAction(() => money.CurrentMG.TargetMoney?.Mover.MoveBase(moveParams));
		money.CurrentMG.MoneyList.Remove(money);            // 現在のMGのリストから除外

		transform.DOMove(money.TargetMG.transform.position, moveParams.Duration)
			.OnComplete(() => {
				transform.SetParent(money.TargetMG.RectTransform);      // MGを親に指定
				money.ChangeCurrentMoneyGroup();					// moneyの現在のMoneyGroupを変更
			});
	}

	// 直接現在のMG、目標のMGを指定する(仮)
	void MoveBase(MovementParams moveParams, MoneyGroupUnit current, MoneyGroupUnit target)
	{
		target.MoneyList.Add(money);
		current.ChangeButtonAction(() => current.TargetMoney?.Mover.MoveBase(moveParams, current, target));
		current.MoneyList.Remove(money);

		transform.DOMove(target.transform.position, moveParams.Duration)
			.OnComplete(() => {
				transform.SetParent(target.RectTransform);      // MGを親に指定
				money.ChangeCurrentMoneyGroup();                    // moneyの現在のMoneyGroupを変更
			});
	}
}
