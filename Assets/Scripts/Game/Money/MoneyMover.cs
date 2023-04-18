using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Cysharp.Threading.Tasks;
using static UnityEngine.GraphicsBuffer;

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
	}


    //--------------------------------------------------

    void Awake()
    {
        
    }

	public void MoveBase()
	{
		transform.DOMove(money.CurrentMG.targetMG.transform.position, moveParams.Duration)
			.OnComplete(() => {
				transform.SetParent(money.CurrentMG.RectTransform);      // MGを親に指定
			});

		money.CurrentMG.targetMG.MoneyList.Add(money);            // 目標のMGのリストに追加
		money.CurrentMG.MoneyList.Remove(money);        // 現在のMGのリストから除外
		money.ChangeCurrentMG();

		money.AddButtonActions();				// ボタンのActionを変更
	}
}
