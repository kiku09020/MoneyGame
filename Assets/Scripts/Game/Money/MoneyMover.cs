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
		MoveBase(toPaymentMG);
	}

	/// <summary>
	/// プレイヤーのMoneyGroupに移動
	/// </summary>
	public void MoveToPlayerMG()
	{
		MoveBase(toPlayerMG);
	}

	// 基底メソッド
	void MoveBase(MovementParams moveParams)
	{
		transform.DOMove(money.TargetMG.transform.position, moveParams.Duration)
			.OnComplete(() => {

				money.TargetMG.MoneyList.Add(money);                // 移動先のMGのリストに追加
				money.CurrentMG.ChangeButtonAction(() => money.CurrentMG.TargetMoney?.Mover.MoveBase(moveParams));
				money.CurrentMG.MoneyList.Remove(money);			// 現在のMGのリストから除外

				transform.SetParent(money.TargetMG.RectTransform);      // MGを親に指定

				money.ChangeCurrentMoneyGroup();					// moneyの現在のMoneyGroupを変更
			});
	}
}
