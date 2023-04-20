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
		money.CurrentMG?.MoneyList.Remove(money);                   // ���݂�MG�̃��X�g���珜�O
		money.CurrentMG.targetMG.AddMoney(removeTargetMoney);

		// ���݂�MG��؂�ւ���
		if (changeCurrentMG) {
			money.ChangeCurrentMG();
		}

		money.AddButtonActions();               // �{�^����Action��ύX
	}

	void MoveBase(MoneyGroupUnit targetMoneyGroup, bool changeCurrentMG = true, bool removeTargetMoney = false)
	{
		transform.DOMove(targetMoneyGroup.transform.position, moveParams.Duration)
			.OnComplete(() => {
				transform.SetParent(targetMoneyGroup.RectTransform);    // MG��e�Ɏw��
			});

		targetMoneyGroup?.MoneyList.Add(money);							// �ڕW��MG�̃��X�g�ɒǉ�
		targetMoneyGroup?.targetMG.MoneyList.Remove(money);				// ���݂�MG�̃��X�g���珜�O
		targetMoneyGroup.AddMoney(removeTargetMoney);					// ���z�A�����ǉ�

		// ���݂�MG��؂�ւ���
		if (changeCurrentMG) {
			money.ChangeCurrentMG();
		}

		money.AddButtonActions();				// �{�^����Action��ύX
	}

	/// <summary>
	/// �ڕW��MG�܂ňړ�
	/// </summary>
	/// <param name="changeCurrentMG"></param>
	public void MoveToTargetMG(bool changeCurrentMG = true, bool removeTargetMoney = false)
	{
		MoveBase(money.CurrentMG.targetMG, changeCurrentMG,removeTargetMoney);
	}

	/// <summary>
	/// ���݂�MG�܂ňړ�
	/// </summary>
	/// <param name="changeCurrentMG"></param>
	public void MoveToCurrentMG(bool changeCurrentMG = true, bool removeTargetMoney = false)
	{
		MoveBase(money.CurrentMG, changeCurrentMG,removeTargetMoney);
	}
}
