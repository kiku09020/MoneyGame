using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Money:MonoBehaviour
{
	[Header("Data")]
    [SerializeField] MoneyData data;


	[Header("MoneyGroups")]
	[SerializeField] MoneyGroupUnit playerMG;
	[SerializeField] MoneyGroupUnit paymentMG;

	public MoneyGroupUnit CurrentMG { get; private set; }
	public MoneyGroupUnit TargetMG { get; private set; }

	[Header("Components")]
	[SerializeField] RectTransform rectTransform;
	[SerializeField] Image image;
	[SerializeField] MoneyMover mover;
	[SerializeField] MoneyCalculater calculater;

    // Proparties
    public MoneyData Data => data;

	public RectTransform RectTransform => rectTransform;
	public MoneyMover Mover => mover;
	public MoneyCalculater Calculater => calculater;

	public MoneyGroupUnit PlayerMG => playerMG;
	public MoneyGroupUnit PaymentMG => paymentMG;

	//--------------------------------------------------

	private void OnValidate()
	{
		if (data != null) {
			image.sprite = data.Sprite;
		}
	}

	// 生成時の処理
	public void Generated(List<MoneyGenerator.MoneyUnit> moneyList)
	{
		paymentMG = moneyList[data.Number].PaymentMG;
		playerMG = moneyList[data.Number].PlayerMG;

		TargetMG = paymentMG;
		CurrentMG = playerMG;
	}

	/// <summary>
	/// MoneyGroupの変更
	/// </summary>
	public void ChangeCurrentMoneyGroup(MoneyGroupUnit currentMoneyGroup,MoneyGroupUnit targetMoneyGroup)
	{
		TargetMG = targetMoneyGroup;
		CurrentMG = currentMoneyGroup;
	}

	/// <summary>
	/// 現在のMGを変更(没。後々改良予定)
	/// </summary>
	public void ChangeCurrentMoneyGroup()
	{
		TargetMG = CurrentMG;

		if (CurrentMG == paymentMG) {
			CurrentMG = playerMG;
		}

		else if (CurrentMG == playerMG) {
			CurrentMG = paymentMG;
		}
	}

	/// <summary>
	/// ボタンのOnClick()にActionを追加
	/// </summary>
	public void AddButtonActions()
	{
		// 所持金MG
		CurrentMG.AddButtonAction(Mover.MoveToPaymentMG);
		CurrentMG.AddButtonAction(() => Calculater.AddPaymentAmount(true));
		CurrentMG.AddButtonAction(() => Calculater.AddPaymentCount(true));

		// 支払額MG
		TargetMG.AddButtonAction(Mover.MoveToPlayerMG);
		TargetMG.AddButtonAction(() => Calculater.AddPocketAmount(true));
		TargetMG.AddButtonAction(() => Calculater.AddPocketAmount(true));
	}
}
