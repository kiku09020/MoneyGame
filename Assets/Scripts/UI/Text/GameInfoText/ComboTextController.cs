using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.UIController {
	public class ComboTextController : GeneratableTextController {

		//--------------------------------------------------

		public override void SetText<T>(T value)
		{
			var intValue = Convert.ToInt32(value);

			uiObject.text = $"Å~{intValue}";
		}
	}
}