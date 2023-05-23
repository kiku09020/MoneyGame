using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Money.MoneyManager.Evaluator {
    public abstract class Evaluator_Correct : Evaluator_Base {

        [SerializeField, Tooltip("���Z����鎞��")] float addedTime = 2;

        public float AddedTime => addedTime;

        /// <summary>
        /// ���Z�X�R�A
        /// </summary>
        public abstract int AddedScore { get; }

		//--------------------------------------------------
    }
}