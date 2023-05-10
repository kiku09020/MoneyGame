using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.TextController {
	public class ComboTextController : TextController_Base {

		//--------------------------------------------------

		private void Awake()
		{
			SetText();
		}

		public void SetText()
		{
			var comboText = ScoreManager.ComboCount.ToString();

			text.text = $"x{comboText}";
		}
	}
}