using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Debug_ {
    public class TimeDebugger : MonoBehaviour {
        DebugInput inputActions;

        //--------------------------------------------------

        void Awake()
        {
            inputActions = new DebugInput();

            inputActions.Time.Stop.performed += OnStop;
            inputActions.Time.FastSpeed.performed += OnFast;
            inputActions.Time.SlowSpeed.performed += OnSlow;

            inputActions.Enable();
        }

        private void OnDestroy()
        {
            inputActions.Time.Stop.performed -= OnStop;
            inputActions.Time.FastSpeed.performed -= OnFast;
            inputActions.Time.SlowSpeed.performed -= OnSlow;
        }

        void OnStop(InputAction.CallbackContext callbackContext)
        {
            TimeController.Stop();
        }

        void OnFast(InputAction.CallbackContext callbackContext)
        {
            TimeController.ChangeTimeScale(2, true);
        }

        void OnSlow(InputAction.CallbackContext callbackContext)
        {
            TimeController.ChangeTimeScale(0.5f, true);
        }
    }
}