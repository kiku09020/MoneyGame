using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoneyGroupUnit : MonoBehaviour {
    [Header("Components")]
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Button button;

    public RectTransform RectTransform => rectTransform;

    List<Money> moneyList = new List<Money>();
    public List<Money> MoneyList => moneyList;

    public Money TargetMoney {
        get {
            if (moneyList.Count > 0) {
                return moneyList[moneyList.Count - 1];
            }

            return null;
        }
    }

//--------------------------------------------------

void Awake()
    {
        
    }

    /// <summary>
    /// É{É^ÉìÇÃOnClick()ÇïœçXÇ∑ÇÈ
    /// </summary>
    public void ChangeButtonAction(Action action)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(action.Invoke);
    }
}
