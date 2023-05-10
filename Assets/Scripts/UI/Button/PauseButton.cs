using GameController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.Button {
    using State;

    public class PauseButton : MonoBehaviour {
        [SerializeField] GameStateMachine state;

        //--------------------------------------------------

        void Awake()
        {

        }

        public void OnClick()
        {
            state.StateTransition<PauseState>();
        }
    }
}