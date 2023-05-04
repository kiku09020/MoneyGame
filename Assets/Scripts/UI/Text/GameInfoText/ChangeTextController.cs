using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class ChangeTextController : TextController_Generatable
{
	protected override string SetMessage(object value)
	{
		// ����؂�̉~�\��
		var separatedText = WholeMoneyInfo.SeparatedAmountText((int)value);

		return $"+{separatedText}";
	}
}
