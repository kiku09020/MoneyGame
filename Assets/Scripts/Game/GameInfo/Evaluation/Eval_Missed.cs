using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Money.MoneyManager {
    public class Eval_Missed : Evaluator_Base {

		[SerializeField] WholeMoneyCalculator calculator;

		//--------------------------------------------------

		protected override bool Condition()
		{
			var changeList = calculator.GetChangeMoneyList();

			changeList.Reverse();                                       // ����̃��X�g�̏����𔽓]

			for (int i = 0; i < changeList.Count; i++) {
				if (changeList[i]?.MoneyList?.Count <= 0) continue;     // ����̒P�ʃ��X�g�̐������Ȃ���΁A���̒P�ʂ�

				// �܂܂�Ă�����true
				if (changeList[i].MoneyList[0].Money == moneyInfo.PaymentMG.MoneyGroupUnitList[i].TargetMoney) {
					return true;
				}
			}

			return false;
		}
	}
}