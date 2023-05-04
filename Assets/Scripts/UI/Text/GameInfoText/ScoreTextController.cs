using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextController : TextController_Generatable
{
	protected override string SetMessage(object value)
	{
		// Œ…‹æØ‚è
		var text = string.Format("{0:#,0}", (int)value);

		return $"+{text}";
	}
}
