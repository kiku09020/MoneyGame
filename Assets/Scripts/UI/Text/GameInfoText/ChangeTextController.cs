using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.TextController {
	using Game.Money.MoneyManager;

	public class ChangeTextController : TextController_Generatable {
		protected override string SetMessage(object value)
		{
			// ����؂�̉~�\��
			var separatedText = WholeMoneyInfo.SeparatedAmountText((int)value);

			return $"+{separatedText}";
		}
	}
}