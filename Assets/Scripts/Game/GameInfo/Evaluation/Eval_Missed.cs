using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Money.MoneyManager.Evaluator {
    public class Eval_Missed : Evaluator_Incorrect {
		
		//--------------------------------------------------

		protected override bool Condition(WholeMoneyInfo moneyInfo)
		{
			var changeList = calculator.GetChangeMoneyList();

			changeList.Reverse();                                       // おつりのリストの順序を反転

			for (int i = 0; i < changeList.Count; i++) {
				if (changeList[i]?.MoneyList?.Count <= 0) continue;     // おつりの単位リストの数が少なければ、次の単位へ

				// 含まれていたらtrue
				if (changeList[i].MoneyList[0].Money == moneyInfo.PaymentMG.MoneyGroupUnitList[i].TargetMoney) {
					return true;
				}
			}

			return false;
		}

		protected override void EvaluatedAction()
		{
			base.EvaluatedAction();
		}
	}
}