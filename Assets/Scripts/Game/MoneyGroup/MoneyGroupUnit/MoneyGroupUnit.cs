using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoneyGroupUnit : MonoBehaviour {

    MoneyGroup moneyGroup;
    public MoneyGroupUnit targetMG;

    [Header("Components")]
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Button button;

    // Proparties
    public RectTransform RectTransform => rectTransform;

    List<Money> moneyList = new List<Money>();
    public List<Money> MoneyList => moneyList;

    /// <summary>
    /// �ŐV�̂���
    /// </summary>
    public Money TargetMoney => (moneyList.Count > 0) ? moneyList[moneyList.Count - 1] : null;

    /// <summary>
    /// �e��MoneyGroup
    /// </summary>
    public MoneyGroup MoneyGroup => moneyGroup;

    /// <summary>
    /// ���������邩�ǂ���
    /// </summary>
    public bool IsEmpty => (TargetMoney == null) ? true : false;

	//--------------------------------------------------

	void Awake()
    {
        
    }

    public void SetMoenyGroups(MoneyGroup moneyGroup, MoneyGroupUnit targetMoneyGroupUnit)
    {
        this.moneyGroup = moneyGroup;
        this.targetMG = targetMoneyGroupUnit;
    }

    /// <summary>
    /// �{�^����OnClick()�ɒǉ�����
    /// </summary>
    public void AddButtonAction(Action action, bool removeOldEvents = true)
    {
        if (removeOldEvents) {
            button.onClick.RemoveAllListeners();
        }

        button.onClick.AddListener(action.Invoke);
    }

    /// <summary>
    /// �����̃C�x���g��ǉ�����
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
