using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MoneyGroupCalculator : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] MoneyGroup moneyGroup;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] DispInfoType infoType;


    public enum DispInfoType
    {
        amount,
        count,
    }

    //--------------------------------------------------

    void Awake()
    {
        
    }

	private void FixedUpdate()
	{
        Disp();
	}

    void Disp()
    {
        switch(infoType) {
            case DispInfoType.amount:
                var amountText = String.Format("{0:#,0}", moneyGroup.MoneyAmount);
                text.text = $"¥{amountText}";
                break;

            case DispInfoType.count:
                var countText=moneyGroup.MoneyCount.ToString("D2");
                var maxCountText=WholeMoneyInfo.Instance.PocketMoneyMaxCount.ToString("D2");
                text.text = $"{countText}/{maxCountText}";
                break;
        }
    }
}
