using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Money.MoneyGroup {
    public class MoneyGroup : MonoBehaviour {
        int moneyCount;     // お金の枚数
        int moneyAmount;    // お金の合計金額

        [Header("MoneyGroups")]
        [SerializeField] MoneyGroup targetMoneyGroup;
        [SerializeField] List<MoneyGroupUnit> moneyGroups = new List<MoneyGroupUnit>();

        [Header("Components")]
        [SerializeField] MoneyGroupMover mover;

        // properties
        /// <summary>
        /// Group内の合計枚数
        /// </summary>
        public int MoneyCount => moneyCount;

        /// <summary>
        /// Group内の合計金額
        /// </summary>
        public int MoneyAmount => moneyAmount;

        public List<MoneyGroupUnit> MoneyGroupUnitList => moneyGroups;

        public MoneyGroupMover Mover => mover;

        //--------------------------------------------------

        void Awake()
        {
            // 相手のMGUnitをセットする
            for (int i = 0; i < moneyGroups.Count; i++) {
                moneyGroups[i].SetMoenyGroups(this, targetMoneyGroup.moneyGroups[i]);
            }
        }

        /// <summary>
        /// 枚数を加算する
        /// </summary>
        /// <param name="count">加算する枚数</param>
        /// <param name="removeTargetMG">相手の枚数から減算するか</param>
        public void AddCount(int count = 1, bool removeTargetMG = true)
        {
            moneyCount += count;

            // フラグが立っていれば、片方の枚数を減算する
            if (removeTargetMG) {
                targetMoneyGroup?.AddCount(-count, false);
            }
        }

        /// <summary>
        /// 金額を加算する
        /// </summary>
        /// <param name="amount">加算する金額</param>
        /// <param name="removeTargetMG">相手の金額から減算するか</param>
        public void AddAmount(int amount, bool removeTargetMG = true)
        {
            moneyAmount += amount;

            // フラグが立っていれば、片方の金額を減算する
            if (removeTargetMG) {
                targetMoneyGroup?.AddAmount(-amount, false);
            }
        }
    }
}