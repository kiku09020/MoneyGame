using DG.Tweening;
using GameController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Money.MoneyManager.Evaluator {

    public class Eval_Perfected : Evaluator_Correct {

		[Header("Parameters")]
		[SerializeField] float scoreMultiple = 1.25f;

		public override int AddedScore => (int)(TargetPriceSetter.TargetPrice * scoreMultiple);

		[Header("Components")]
		[SerializeField] GameTimeManager timeManager;
		[SerializeField] DOTweenAnimation canvasAnimator;

		//--------------------------------------------------

		// ���肪0�~�������Ƃ��A�p�[�t�F�N�g����
		protected override bool Condition(WholeMoneyInfo moneyInfo)
		{
			return (moneyInfo.Change == 0);
		}

		protected override void EvaluatedAction()
		{
			timeManager.StopWholeTime(.5f);					// �ҋ@

			canvasAnimator.DORestartById("Zooming");		// �J�����Y�[���C��
		}
	}
}