using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    [SerializeField] Button button;

	//--------------------------------------------------

	private void FixedUpdate()
	{
        if (MainGameManager.isOperable) {
            button.interactable = true;
        }

        else {
            button.interactable = false;
        }
	}
}
