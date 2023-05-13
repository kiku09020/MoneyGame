using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Game.Money.MoneyManager;

namespace Game.Money.MoneyGroup {
    public class MoneyGroupCalculator : MonoBehaviour {
        [Header("Components")]
        [SerializeField] MoneyGroup moneyGroup;
        [SerializeField] WholeMoneyInfo wholeInfo;

        [Header("Text")]
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] DispInfoType infoType;


        public enum DispInfoType {
            amount,
            count,
        }

        //--------------------------------------------------

        private void FixedUpdate()
        {
            Disp();
        }

        void Disp()
        {
            switch (infoType) {
                case DispInfoType.amount:
                    text.text = WholeMoneyInfo.SeparatedAmountText(moneyGroup.MoneyAmount);
                    break;

                case DispInfoType.count:
                    var countText = moneyGroup.MoneyCount.ToString("D2");
                    var maxCountText = wholeInfo.PocketMoneyMaxCount.ToString("D2");
                    text.text = $"{countText}/{maxCountText}";
                    break;
            }
        }
    }
}