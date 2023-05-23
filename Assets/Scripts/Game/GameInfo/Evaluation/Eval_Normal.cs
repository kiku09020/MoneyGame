using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Money.MoneyManager.Evaluator {

    public class Eval_Normal : Evaluator_Correct {

		public override int AddedScore => TargetPriceSetter.TargetPrice;

		//--------------------------------------------------


		protected override bool Condition(WholeMoneyInfo moneyInfo)
		{
			return true;
		}

		protected override void EvaluatedAction()
		{

		}
	}
}