using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Money.MoneyManager {

    public class Eval_Perfected : Evaluator_Base {

		//--------------------------------------------------

		protected override bool Condition()
		{
			return (moneyInfo.Change == 0);
		}
	}
}