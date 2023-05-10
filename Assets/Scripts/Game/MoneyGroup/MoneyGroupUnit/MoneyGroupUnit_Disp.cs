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
        [SerializeField] bool changeColor;          // �ύX���邩
        [SerializeField] Color targetColor;         // �x���F
        [SerializeField] float duration;            // �ύX���鎞��

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

        // �x���̂��߂Ƀe�L�X�g�̐F��ς���
        void ChangeTextColor()
        {
            // �x���F�ɂ���
            if (moneyGroupUnit.TargetMoney != null && moneyGroupUnit.MoneyList.Count > moneyGroupUnit.TargetMoney.Data.GeneratedCount) {
                text.DOColor(targetColor, duration);
                caution = true;
            }

            // �x���F���猳�̐F�ɖ߂�
            else if (caution) {
                text.DOColor(defaultColor, duration);
                caution = false;
            }
        }
    }
}