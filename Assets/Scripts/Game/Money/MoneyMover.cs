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
	[SerializeField] MovementParams moveParams;

	//--------------------------------------------------

	[Serializable]
	public class MovementParams
	{
		[SerializeField] float duration = 0.25f;
		[SerializeField] Ease easeType = Ease.Unset;

		public float Duration => duration;
		public Ease EaseType => easeType;
	}

    //--------------------------------------------------

	/// <summary>
	/// ボタン押したときに移動
	/// </summary>
	public void ButonMove(bool changeCurrentMG = true, bool removeTargetMoney = true)
	{
		transform.DOMove(money.CurrentMG.targetMG.transform.position, moveParams.Duration)
			.SetEase(moveParams.EaseType)

			.OnComplete(() => {
				transform.SetParent(money.CurrentMG.RectTransform);      // MGを親に指定
			});

		money.CurrentMG.targetMG?.MoneyList.Add(money);             // 目標のMGのリストに追加
		money.CurrentMG?.MoneyList.Remove(money);                   // 現在のMGのリストから除外
		money.CurrentMG.targetMG.AddMoney(removeTargetMoney);

		// 現在のMGを切り替える
		if (changeCurrentMG) {
			money.ChangeCurrentMG();
		}

		money.AddButtonActions();               // ボタンのActionを変更
	}

	void MoveBase(MoneyGroupUnit targetMoneyGroup, bool changeCurrentMG = true, bool removeTargetMoney = false)
	{
		transform.DOMove(targetMoneyGroup.transform.position, moveParams.Duration)
			.OnComplete(() => {
				transform.SetParent(targetMoneyGroup.RectTransform);    // MGを親に指定
			});

		targetMoneyGroup?.MoneyList.Add(money);							// 目標のMGのリストに追加
		targetMoneyGroup?.targetMG.MoneyList.Remove(money);				// 現在のMGのリストから除外
		targetMoneyGroup.AddMoney(removeTargetMoney);					// 金額、枚数追加

		// 現在のMGを切り替える
		if (changeCurrentMG) {
			money.ChangeCurrentMG();
		}

		money.AddButtonActions();				// ボタンのActionを変更
	}

	/// <summary>
	/// 目標のMGまで移動
	/// </summary>
	/// <param name="changeCurrentMG"></param>
	public void MoveToTargetMG(bool changeCurrentMG = true, bool removeTargetMoney = false)
	{
		MoveBase(money.CurrentMG.targetMG, changeCurrentMG,removeTargetMoney);
	}

	/// <summary>
	/// 現在のMGまで移動
	/// </summary>
	/// <param name="changeCurrentMG"></param>
	public void MoveToCurrentMG(bool changeCurrentMG = true, bool removeTargetMoney = false)
	{
		MoveBase(money.CurrentMG, changeCurrentMG,removeTargetMoney);
	}
}
