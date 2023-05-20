using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.TextController {
	using Game.Money.MoneyManager;

	public class ChangeTextController : GeneratableTextController {
		protected override string SetMessage(float value)
		{
			// ����؂�̉~�\��
			var separatedText = WholeMoneyInfo.SeparatedAmountText((int)value);

			return $"+{separatedText}";
		}
	}
}