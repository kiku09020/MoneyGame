using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.Button {
    public class ActionButton : MonoBehaviour {
        [SerializeField] UnityEngine.UI.Button button;

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
}