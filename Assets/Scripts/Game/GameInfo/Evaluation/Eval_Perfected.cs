using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Money.MoneyManager.Evaluator {

    public class Eval_Perfected : Evaluator_Correct {

		[Header("Parameters")]
		[SerializeField] float scoreMultiple = 1.25f;

		public override int AddedScore => (int)(TargetPriceSetter.TargetPrice * scoreMultiple);

		//--------------------------------------------------

		protected override bool Condition(WholeMoneyInfo moneyInfo)
		{
			return (moneyInfo.Change == 0);
		}

		protected override void EvaluatedAction()
		{

		}
	}
}