using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.UIController {
	using Game.Money.MoneyManager;
	using System;

	public class ChangeTextController : GeneratableTextController {
		public override void SetText<T>(T value)
		{
			var intValue = Convert.ToInt32(value);

			// Œ…‹æØ‚è‚Ì‰~•\¦
			var separatedText = WholeMoneyInfo.SeparatedAmountText(intValue);

			uiObject.text = $"+{separatedText}";
		}
	}
}