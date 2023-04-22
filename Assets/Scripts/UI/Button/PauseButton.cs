using GameController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
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
