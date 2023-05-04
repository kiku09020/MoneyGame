using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextController : TextController_Generatable
{
	protected override string SetMessage(object value)
	{
		// ����؂�
		var text = string.Format("{0:#,0}", (int)value);

		return $"+{text}";
	}
}
