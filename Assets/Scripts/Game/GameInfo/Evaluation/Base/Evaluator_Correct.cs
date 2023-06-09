using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Money.MoneyManager.Evaluator {
    public abstract class Evaluator_Correct : Evaluator_Base {

        [SerializeField, Tooltip("加算される時間")] float addedTime = 2;

        public float AddedTime => addedTime;

        /// <summary>
        /// 加算スコア
        /// </summary>
        public abstract int AddedScore { get; }

		//--------------------------------------------------
    }
}