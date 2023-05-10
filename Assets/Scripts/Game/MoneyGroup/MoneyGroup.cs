using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Money.MoneyGroup {
    public class MoneyGroup : MonoBehaviour {
        int moneyCount;     // �����̖���
        int moneyAmount;    // �����̍��v���z

        [Header("MoneyGroups")]
        [SerializeField] MoneyGroup targetMoneyGroup;
        [SerializeField] List<MoneyGroupUnit> moneyGroups = new List<MoneyGroupUnit>();

        [Header("Components")]
        [SerializeField] MoneyGroupMover mover;

        // properties
        /// <summary>
        /// Group���̍��v����
        /// </summary>
        public int MoneyCount => moneyCount;

        /// <summary>
        /// Group���̍��v���z
        /// </summary>
        public int MoneyAmount => moneyAmount;

        public List<MoneyGroupUnit> MoneyGroupUnitList => moneyGroups;

        public MoneyGroupMover Mover => mover;

        //--------------------------------------------------

        void Awake()
        {
            // �����MGUnit���Z�b�g����
            for (int i = 0; i < moneyGroups.Count; i++) {
                moneyGroups[i].SetMoenyGroups(this, targetMoneyGroup.moneyGroups[i]);
            }
        }

        /// <summary>
        /// ���������Z����
        /// </summary>
        /// <param name="count">���Z���閇��</param>
        /// <param name="removeTargetMG">����̖������猸�Z���邩</param>
        public void AddCount(int count = 1, bool removeTargetMG = true)
        {
            moneyCount += count;

            // �t���O�������Ă���΁A�Е��̖��������Z����
            if (removeTargetMG) {
                targetMoneyGroup?.AddCount(-count, false);
            }
        }

        /// <summary>
        /// ���z�����Z����
        /// </summary>
        /// <param name="amount">���Z������z</param>
        /// <param name="removeTargetMG">����̋��z���猸�Z���邩</param>
        public void AddAmount(int amount, bool removeTargetMG = true)
        {
            moneyAmount += amount;

            // �t���O�������Ă���΁A�Е��̋��z�����Z����
            if (removeTargetMG) {
                targetMoneyGroup?.AddAmount(-amount, false);
            }
        }
    }
}