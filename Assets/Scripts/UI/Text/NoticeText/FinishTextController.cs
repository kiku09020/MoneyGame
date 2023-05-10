using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.TextController {
    public class FinishTextController : TextController_Base {
        [Header("Parameters")]
        [SerializeField] string message;
        //--------------------------------------------------

        public void StartingAction()
        {
            text.gameObject.SetActive(true);        // •\Ž¦

            DispText(message);
        }
    }
}