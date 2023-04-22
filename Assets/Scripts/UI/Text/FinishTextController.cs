using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTextController : TextController_Base
{
    [SerializeField] TextUnit textUnit;

    //--------------------------------------------------

    public void StartingAction()
    {
		text.gameObject.SetActive(true);        // �\��

        textUnit.DispText(text, token);
	}
}
