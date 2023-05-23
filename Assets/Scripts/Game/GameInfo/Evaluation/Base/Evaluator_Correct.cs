using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Money.MoneyManager.Evaluator {
    public abstract class Evaluator_Correct : Evaluator_Base {

        [SerializeField, Tooltip("‰ÁZ‚³‚ê‚éŠÔ")] float addedTime = 2;

        public float AddedTime => addedTime;

        /// <summary>
        /// ‰ÁZƒXƒRƒA
        /// </summary>
        public abstract int AddedScore { get; }

		//--------------------------------------------------
    }
}