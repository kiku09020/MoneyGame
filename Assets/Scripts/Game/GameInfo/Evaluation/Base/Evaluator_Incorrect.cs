using DG.Tweening;
using Game.Money.MoneyManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Money.MoneyManager.Evaluator {
    public abstract class Evaluator_Incorrect : Evaluator_Base {
        [Header("Parameters")]
        [SerializeField, Tooltip("減算される時間")] float removedTime = 5;

        [Header("Components")]
        [SerializeField] protected WholeMoneyCalculator calculator;

		[Header("Effects")]
		[SerializeField] DOTweenAnimation canvasAnimator;

		public float RemovedTime => removedTime;

		//--------------------------------------------------

		protected override void EvaluatedAction()
		{
			canvasAnimator.DORestartById("Shaking");		// 画面揺らす
		}
	}
}