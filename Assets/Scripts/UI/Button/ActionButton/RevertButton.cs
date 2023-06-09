using Game.Money.MoneyManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.Button {
    public class RevertButton : ActionButton {

		// 支払金額が目標額以上だったらクリック可能
		protected override bool Clickable => (moneyInfo.PaymentMG.MoneyCount != 0) ? true : false;

		//--------------------------------------------------

		protected override void ClickedAction()
		{
			moneyInfo.PaymentMG.Mover.MoveToTarget(true, true, false);
		}

		protected override void CantClickAction()
		{

		}
	}
}