using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Money.MoneyManager {

    public class Eval_Overed : Evaluator_Base {

		[SerializeField] WholeMoneyCalculator calculator;

		//--------------------------------------------------

		protected override bool Condition()
		{
			// ����̐����ő及�����������傫�����ǂ���
			return ((calculator.GetChangeCount() + moneyInfo.PocketMG.MoneyCount) > moneyInfo.PocketMoneyMaxCount);
		}
	}
}