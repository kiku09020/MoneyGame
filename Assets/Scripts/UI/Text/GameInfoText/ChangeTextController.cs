using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.TextController {
	using Game.Money.MoneyManager;

	public class ChangeTextController : GeneratableTextController {
		public override void SetTextMessage(float value)
		{
			// Œ…‹æØ‚è‚Ì‰~•\¦
			var separatedText = WholeMoneyInfo.SeparatedAmountText((int)value);

			uiObject.text = $"+{separatedText}";
		}
	}
}