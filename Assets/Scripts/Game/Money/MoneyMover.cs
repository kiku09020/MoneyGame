using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime;
using System.Threading;

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
		[SerializeField] int waitFrames = 5;

		public float Duration => duration;
		public Ease EaseType => easeType;
		public int WaitFrames => waitFrames;
	}

	CancellationToken token;

	private void Awake()
	{
		token = this.GetCancellationTokenOnDestroy();
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

		if (removeTargetMoney) {
			money.CurrentMG?.MoneyList.Remove(money);                   // 現在のMGのリストから除外
		}

		money.CurrentMG.targetMG.AddMoney(removeTargetMoney);

		// 現在のMGを切り替える
		if (changeCurrentMG) {
			money.ChangeCurrentMG();
		}

		money.AddButtonActions();               // ボタンのActionを変更
	}

	//--------------------------------------------------

	public async UniTask MoveBase(MoneyGroupUnit targetMoneyGroup, bool changeCurrentMG = true, bool removeTargetMoney = false, bool wait = false)
	{
		transform.DOMove(targetMoneyGroup.transform.position, moveParams.Duration)
			.SetEase (moveParams.EaseType)
			.OnComplete(() => {
				transform.SetParent(targetMoneyGroup.RectTransform);    // MGを親に指定
			});

		targetMoneyGroup?.MoneyList.Add(money);                         // 目標のMGのリストに追加

		if (removeTargetMoney) {
			targetMoneyGroup?.targetMG.MoneyList.Remove(money);				// 現在のMGのリストから除外
		}

		targetMoneyGroup.AddMoney(removeTargetMoney);					// 金額、枚数追加

		// 現在のMGを切り替える
		if (changeCurrentMG) {
			money.ChangeCurrentMG();
		}

		money.AddButtonActions();               // ボタンのActionを変更

		// 待機
		await Wait(wait);
	}

	//--------------------------------------------------

	/// <summary>
	/// 目標のMGまで移動
	/// </summary>
	/// <param name="changeCurrentMG"></param>
	public async UniTask MoveToTargetMG(bool changeCurrentMG = true, bool removeTargetMoney = false, bool wait = false)
	{
		await MoveBase(money.CurrentMG.targetMG, changeCurrentMG, removeTargetMoney, wait);
	}

	/// <summary>
	/// 現在のMGまで移動
	/// </summary>
	/// <param name="changeCurrentMG"></param>
	public async UniTask MoveToCurrentMG(bool changeCurrentMG = true, bool removeTargetMoney = false, bool wait = false)
	{
		await MoveBase(money.CurrentMG, changeCurrentMG, removeTargetMoney, wait);
	}

	//--------------------------------------------------

	/// <summary>
	/// MGからレクトに移動する
	/// </summary>
	public async UniTask MGMoneyToTargetRect(Transform transform, bool wait = false)
	{
		// 移動
		money.transform.DOMove(transform.position, moveParams.Duration)
			.SetEase(moveParams.EaseType)
			.OnComplete(() => {
				Destroy(money.gameObject);
			});

		money.CurrentMG.RemoveMoney();
		money.CurrentMG.MoneyList.Remove(money);           // 現在のMGのリストから除外
		

		await Wait(wait);
	}

	//--------------------------------------------------

	async UniTask Wait(bool wait)
	{
		if (wait) {
			await UniTask.DelayFrame(moveParams.WaitFrames, PlayerLoopTiming.FixedUpdate, cancellationToken: token);
		}
	}
}
