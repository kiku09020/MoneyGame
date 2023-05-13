using Game.Money.MoneyManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.Button {
    public class RevertButton : ActionButton {

		// Žx•¥‹àŠz‚ª–Ú•WŠzˆÈã‚¾‚Á‚½‚çƒNƒŠƒbƒN‰Â”\
		protected override bool Clickable => (moneyInfo.PaymentMG.MoneyAmount >= TargetPriceSetter.TargetPrice) ? true : false;

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