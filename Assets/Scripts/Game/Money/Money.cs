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

	[Header("Target")]
	[SerializeField] MoneyGroup targetPlayerMG;
	[SerializeField] MoneyGroup targetPaymentMG;

	[Header("Components")]
	[SerializeField] RectTransform rectTransform;
	[SerializeField] Image image;

    // Proparties
    public MoneyData Data => data;

	public RectTransform RectTransform => rectTransform;

	public MoneyGroup TargetPlayerMG => targetPlayerMG;
	public MoneyGroup TargetPaymentMG => targetPaymentMG;

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
		targetPaymentMG = moneyList[data.Number].TargetPaymentMG;
		targetPlayerMG = moneyList[data.Number].TargetPlayerMG;
	}
}
