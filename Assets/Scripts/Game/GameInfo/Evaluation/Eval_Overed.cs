using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Money.MoneyManager.Evaluator {

    public class Eval_Overed : Evaluator_Incorrect {

		//--------------------------------------------------

		protected override bool Condition(WholeMoneyInfo moneyInfo)
		{
			// おつりの数が最大所持枚数よりも大きいかどうか
			return ((calculator.GetChangeCount() + moneyInfo.PocketMG.MoneyCount) > moneyInfo.PocketMoneyMaxCount);
		}

		protected override void EvaluatedAction()
		{
			base.EvaluatedAction();
		}
	}
}