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

    // Proparties
    public MoneyData Data => data;

	public RectTransform RectTransform => rectTransform;
	public MoneyMover Mover => mover;

	public MoneyGroupUnit PlayerMG => playerMG;
	public MoneyGroupUnit PaymentMG => paymentMG;

	//--------------------------------------------------

	private void OnValidate()
	{
		if (data != null) {
			image.sprite = data.Sprite;
		}
	}

	// ¶¬‚Ìˆ—
	public void Generated(List<MoneyGenerator.MoneyUnit> moneyList)
	{
		paymentMG = moneyList[data.Number].PaymentMG;
		playerMG = moneyList[data.Number].PlayerMG;

		TargetMG = paymentMG;
		CurrentMG = playerMG;
	}

	/// <summary>
	/// MoneyGroup‚Ì•ÏX
	/// </summary>
	public void ChangeCurrentMoneyGroup(MoneyGroupUnit moneyGroup)
	{
		TargetMG = CurrentMG;
		CurrentMG = moneyGroup;
	}

	public void ChangeCurrentMoneyGroup(MoneyGroupUnit currentMoneyGroup,MoneyGroupUnit targetMoneyGroup)
	{
		TargetMG = targetMoneyGroup;
		CurrentMG = currentMoneyGroup;
	}

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
}
