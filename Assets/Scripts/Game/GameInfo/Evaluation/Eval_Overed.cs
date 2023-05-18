using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Money.MoneyManager {

    public class Eval_Overed : Evaluator_Base {

		[SerializeField] WholeMoneyCalculator calculator;

		//--------------------------------------------------

		protected override bool Condition()
		{
			// ‚¨‚Â‚è‚Ì”‚ªÅ‘åŠŽ–‡”‚æ‚è‚à‘å‚«‚¢‚©‚Ç‚¤‚©
			return ((calculator.GetChangeCount() + moneyInfo.PocketMG.MoneyCount) > moneyInfo.PocketMoneyMaxCount);
		}
	}
}