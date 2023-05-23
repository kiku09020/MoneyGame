using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.TextController {
	public class ComboTextController : TextController {

		//--------------------------------------------------

		public override void SetTextMessage(float value)
		{
			uiObject.text = $"�~{value}";
		}
	}
}