using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

using Manager = Game.Money.MoneyManager;

namespace Game.Money.MoneyGroup {
    public class MoneyGroupCalculator : MonoBehaviour {
        [Header("Components")]
        [SerializeField] MoneyGroup moneyGroup;

        [Header("Text")]
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] DispInfoType infoType;


        public enum DispInfoType {
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
            switch (infoType) {
                case DispInfoType.amount:
                    text.text = Manager.WholeMoneyInfo.SeparatedAmountText(moneyGroup.MoneyAmount);
                    break;

                case DispInfoType.count:
                    var countText = moneyGroup.MoneyCount.ToString("D2");
                    var maxCountText = Manager.WholeMoneyInfo.Instance.PocketMoneyMaxCount.ToString("D2");
                    text.text = $"{countText}/{maxCountText}";
                    break;
            }
        }
    }
}