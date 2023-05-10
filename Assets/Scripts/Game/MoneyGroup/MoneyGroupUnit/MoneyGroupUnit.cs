using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Money.MoneyGroup {
    public class MoneyGroupUnit : MonoBehaviour {

        MoneyGroup moneyGroup;
        [HideInInspector] public MoneyGroupUnit targetMG;

        [Header("Components")]
        [SerializeField] RectTransform rectTransform;
        [SerializeField] Button button;

        // Proparties
        public RectTransform RectTransform => rectTransform;

        List<Money> moneyList = new List<Money>();
        public List<Money> MoneyList => moneyList;

        /// <summary>
        /// 最新のお金
        /// </summary>
        public Money TargetMoney => (moneyList.Count > 0) ? moneyList[moneyList.Count - 1] : null;

        /// <summary>
        /// 親のMoneyGroup
        /// </summary>
        public MoneyGroup MoneyGroup => moneyGroup;

        /// <summary>
        /// お金があるかどうか
        /// </summary>
        public bool IsEmpty => (TargetMoney == null) ? true : false;

        //--------------------------------------------------

        // moneyGroupと目的のmoneyGroupUnitを指定(moneyGroupで適用)
        public void SetMoenyGroups(MoneyGroup moneyGroup, MoneyGroupUnit targetMoneyGroupUnit)
        {
            this.moneyGroup = moneyGroup;
            this.targetMG = targetMoneyGroupUnit;
        }

        //--------------------------------------------------

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

            foreach (var action in actions) {
                button.onClick.AddListener(action.Invoke);
            }
        }

        //--------------------------------------------------

        public void AddMoney(bool removeFlag = false)
        {
            if (TargetMoney != null) {
                MoneyGroup.AddAmount(TargetMoney.Data.Amount, removeFlag);
                MoneyGroup.AddCount(1, removeFlag);
            }
        }

        public void RemoveMoney()
        {
            if (TargetMoney != null) {
                MoneyGroup.AddAmount(-TargetMoney.Data.Amount, false);
                MoneyGroup.AddCount(-1, false);
            }
        }
    }
}