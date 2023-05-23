using Game.Money.MoneyManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Money.MoneyManager.Evaluator {
    public abstract class Evaluator_Incorrect : Evaluator_Base {
        [Header("Components")]
        [SerializeField] protected WholeMoneyCalculator calculator;

        [Header("Parameters")]
        [SerializeField, Tooltip("Œ¸ŽZ‚³‚ê‚éŽžŠÔ")] float removedTime = 5;

        public float RemovedTime => removedTime;

        //--------------------------------------------------
    }
}