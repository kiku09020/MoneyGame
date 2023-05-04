using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTextController : TextController_Base
{
    //--------------------------------------------------

    public void StartingAction()
    {
		text.gameObject.SetActive(true);        // •\Ž¦

        DispText(text, token);
	}
}
