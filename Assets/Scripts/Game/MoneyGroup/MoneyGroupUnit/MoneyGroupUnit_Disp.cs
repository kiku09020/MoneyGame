using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.Money.MoneyGroup {
    public class MoneyGroupUnit_Disp : MonoBehaviour {
        [Header("Components")]
        [SerializeField] MoneyGroupUnit moneyGroupUnit;
        [SerializeField] TextMeshProUGUI text;

        [Header("UI")]
        [SerializeField] bool changeColor;          // 変更するか
        [SerializeField] Color targetColor;         // 警告色
        [SerializeField] float duration;            // 変更する時間

        Color defaultColor;

        bool caution;

        //--------------------------------------------------

        private void Awake()
        {
            defaultColor = text.color;
        }

        private void FixedUpdate()
        {
            text.text = moneyGroupUnit.MoneyList.Count.ToString();

            if (changeColor) {
                ChangeTextColor();
            }
        }

        // 警告のためにテキストの色を変える
        void ChangeTextColor()
        {
            // 警告色にする
            if (moneyGroupUnit.TargetMoney != null && moneyGroupUnit.MoneyList.Count > moneyGroupUnit.TargetMoney.Data.GeneratedCount) {
                text.DOColor(targetColor, duration);
                caution = true;
            }

            // 警告色から元の色に戻す
            else if (caution) {
                text.DOColor(defaultColor, duration);
                caution = false;
            }
        }
    }
}