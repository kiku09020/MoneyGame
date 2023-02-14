using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Debug_ {
    public class SceneDebuger : MonoBehaviour {

        SceneInput inputActions;

        private void Awake()
        {
            inputActions = new SceneInput();


            inputActions.Debug.LoadPrevScene.performed += LoadPrevScene;
            inputActions.Debug.LoadNextScene.performed += LoadNextScene;

            inputActions.Enable();
        }

        void LoadPrevScene(InputAction.CallbackContext callbackContext)
        {
            SceneControllerAsync.Instance.LoadPrevScene();
        }

        void LoadNextScene(InputAction.CallbackContext callbackContext)
        {
            SceneControllerAsync.Instance.LoadNextScene();
        }
    }
}