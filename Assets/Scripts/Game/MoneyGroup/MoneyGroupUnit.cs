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
    /// ボタンのOnClick()に追加する
    /// </summary>
    public void AddButtonAction(Action action, bool removeOldEvents = true)
    {
        if (removeOldEvents) {
            button.onClick.RemoveAllListeners();
        }

        button.onClick.AddListener(action.Invoke);
    }

    /// <summary>
    /// 複数のイベントを追加する
    /// </summary>
	public void AddButtonAction(bool removeOldEvents = true, params Action[] actions)
	{
        if (removeOldEvents) {
            button.onClick.RemoveAllListeners();
        }

		foreach(var action in actions) {
            button.onClick.AddListener(action.Invoke);
        }
	}
}
