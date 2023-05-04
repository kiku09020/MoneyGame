using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluateTextController : TextController_Generatable
{
	protected override string SetMessage(object value)
	{
		return value.ToString();
	}
}
