using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTextController : TextController_Generatable
{
	protected override string SetMessage(object value)
	{
		// Œ…‹æØ‚è‚Ì‰~•\¦
		var separatedText = WholeMoneyInfo.SeparatedAmountText((int)value);

		return $"+{separatedText}";
	}
}
