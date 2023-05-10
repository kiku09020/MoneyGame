using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Money.MoneyGroup {
    public class MoneyGroup : MonoBehaviour {
        int moneyCount;     // ‚¨‹à‚Ì–‡”
        int moneyAmount;    // ‚¨‹à‚Ì‡Œv‹àŠz

        [Header("MoneyGroups")]
        [SerializeField] MoneyGroup targetMoneyGroup;
        [SerializeField] List<MoneyGroupUnit> moneyGroups = new List<MoneyGroupUnit>();

        [Header("Components")]
        [SerializeField] MoneyGroupMover mover;

        // properties
        /// <summary>
        /// Group“à‚Ì‡Œv–‡”
        /// </summary>
        public int MoneyCount => moneyCount;

        /// <summary>
        /// Group“à‚Ì‡Œv‹àŠz
        /// </summary>
        public int MoneyAmount => moneyAmount;

        public List<MoneyGroupUnit> MoneyGroupUnitList => moneyGroups;

        public MoneyGroupMover Mover => mover;

        //--------------------------------------------------

        void Awake()
        {
            // ‘Šè‚ÌMGUnit‚ğƒZƒbƒg‚·‚é
            for (int i = 0; i < moneyGroups.Count; i++) {
                moneyGroups[i].SetMoenyGroups(this, targetMoneyGroup.moneyGroups[i]);
            }
        }

        /// <summary>
        /// –‡”‚ğ‰ÁZ‚·‚é
        /// </summary>
        /// <param name="count">‰ÁZ‚·‚é–‡”</param>
        /// <param name="removeTargetMG">‘Šè‚Ì–‡”‚©‚çŒ¸Z‚·‚é‚©</param>
        public void AddCount(int count = 1, bool removeTargetMG = true)
        {
            moneyCount += count;

            // ƒtƒ‰ƒO‚ª—§‚Á‚Ä‚¢‚ê‚ÎA•Ğ•û‚Ì–‡”‚ğŒ¸Z‚·‚é
            if (removeTargetMG) {
                targetMoneyGroup?.AddCount(-count, false);
            }
        }

        /// <summary>
        /// ‹àŠz‚ğ‰ÁZ‚·‚é
        /// </summary>
        /// <param name="amount">‰ÁZ‚·‚é‹àŠz</param>
        /// <param name="removeTargetMG">‘Šè‚Ì‹àŠz‚©‚çŒ¸Z‚·‚é‚©</param>
        public void AddAmount(int amount, bool removeTargetMG = true)
        {
            moneyAmount += amount;

            // ƒtƒ‰ƒO‚ª—§‚Á‚Ä‚¢‚ê‚ÎA•Ğ•û‚Ì‹àŠz‚ğŒ¸Z‚·‚é
            if (removeTargetMG) {
                targetMoneyGroup?.AddAmount(-amount, false);
            }
        }
    }
}