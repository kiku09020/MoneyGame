using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.TextController {
	public class TimeTextController : TextController_Generatable {
		protected override string SetMessage(object value)
		{
			// •„†”»’è
			var signText = ((float)value > 0) ? "+" : "-";

			var absValue = Mathf.Abs((float)value);

			return $"{signText}{absValue}s";
		}
	}
}