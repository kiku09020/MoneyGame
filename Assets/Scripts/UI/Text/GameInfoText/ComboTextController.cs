using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboTextController : TextController_Base
{

	//--------------------------------------------------

	private void Awake()
	{
		SetText();
	}

	public void SetText()
    {
        var comboText = ScoreManager.Combo.ToString();

        text.text = $"x{comboText}";
    }
}
