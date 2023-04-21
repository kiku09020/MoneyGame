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
	/// �{�^���������Ƃ��Ɉړ�
	/// </summary>
	public void ButonMove(bool changeCurrentMG = true, bool removeTargetMoney = true)
	{
		transform.DOMove(money.CurrentMG.targetMG.transform.position, moveParams.Duration)
			.SetEase(moveParams.EaseType)

			.OnComplete(() => {
				transform.SetParent(money.CurrentMG.RectTransform);      // MG��e�Ɏw��
			});

		money.CurrentMG.targetMG?.MoneyList.Add(money);             // �ڕW��MG�̃��X�g�ɒǉ�

		if (removeTargetMoney) {
			money.CurrentMG?.MoneyList.Remove(money);                   // ���݂�MG�̃��X�g���珜�O
		}

		money.CurrentMG.targetMG.AddMoney(removeTargetMoney);

		// ���݂�MG��؂�ւ���
		if (changeCurrentMG) {
			money.ChangeCurrentMG();
		}

		money.AddButtonActions();               // �{�^����Action��ύX
	}

	//--------------------------------------------------

	public async UniTask MoveBase(MoneyGroupUnit targetMoneyGroup, bool changeCurrentMG = true, bool removeTargetMoney = false, bool wait = false)
	{
		transform.DOMove(targetMoneyGroup.transform.position, moveParams.Duration)
			.SetEase (moveParams.EaseType)
			.OnComplete(() => {
				transform.SetParent(targetMoneyGroup.RectTransform);    // MG��e�Ɏw��
			});

		targetMoneyGroup?.MoneyList.Add(money);                         // �ڕW��MG�̃��X�g�ɒǉ�

		if (removeTargetMoney) {
			targetMoneyGroup?.targetMG.MoneyList.Remove(money);				// ���݂�MG�̃��X�g���珜�O
		}

		targetMoneyGroup.AddMoney(removeTargetMoney);					// ���z�A�����ǉ�

		// ���݂�MG��؂�ւ���
		if (changeCurrentMG) {
			money.ChangeCurrentMG();
		}

		money.AddButtonActions();               // �{�^����Action��ύX

		// �ҋ@
		await Wait(wait);
	}

	//--------------------------------------------------

	/// <summary>
	/// �ڕW��MG�܂ňړ�
	/// </summary>
	/// <param name="changeCurrentMG"></param>
	public async UniTask MoveToTargetMG(bool changeCurrentMG = true, bool removeTargetMoney = false, bool wait = false)
	{
		await MoveBase(money.CurrentMG.targetMG, changeCurrentMG, removeTargetMoney, wait);
	}

	/// <summary>
	/// ���݂�MG�܂ňړ�
	/// </summary>
	/// <param name="changeCurrentMG"></param>
	public async UniTask MoveToCurrentMG(bool changeCurrentMG = true, bool removeTargetMoney = false, bool wait = false)
	{
		await MoveBase(money.CurrentMG, changeCurrentMG, removeTargetMoney, wait);
	}

	//--------------------------------------------------

	/// <summary>
	/// MG���烌�N�g�Ɉړ�����
	/// </summary>
	public async UniTask MGMoneyToTargetRect(Transform transform, bool wait = false)
	{
		// �ړ�
		money.transform.DOMove(transform.position, moveParams.Duration)
			.SetEase(moveParams.EaseType)
			.OnComplete(() => {
				Destroy(money.gameObject);
			});

		money.CurrentMG.RemoveMoney();
		money.CurrentMG.MoneyList.Remove(money);           // ���݂�MG�̃��X�g���珜�O
		

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
