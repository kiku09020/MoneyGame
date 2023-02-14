using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Debug_ {
    public class SceneDebugger : MonoBehaviour {

        DebugInput inputActions;

        private void Awake()
        {
            inputActions = new DebugInput();


            inputActions.Scene.LoadPrevScene.performed += LoadPrevScene;
            inputActions.Scene.LoadNextScene.performed += LoadNextScene;
            inputActions.Scene.LoadNowScene.performed += LoadNowScene;

            inputActions.Enable();
        }

		private void OnDestroy()
		{
            inputActions.Scene.LoadPrevScene.performed -= LoadPrevScene;
            inputActions.Scene.LoadNextScene.performed -= LoadNextScene;
            inputActions.Scene.LoadNowScene.performed -= LoadNowScene;

            inputActions.Disable();
        }

		void LoadNowScene(InputAction.CallbackContext callbackContext)
		{
            SceneControllerAsync.Instance.LoadNowScene();
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