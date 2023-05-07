using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

#if DEBUG

public class DebugManager : MonoBehaviour {
    [SerializeField] List<DebugUnit> debugUnits = new List<DebugUnit>();
    [SerializeField] string mainSceneName;

    protected void Awake()
    {
        // デバッグビルド以外は早期リターン
        if (!Debug.isDebugBuild) return;

        // メインシーンでのみ実行
        if (SceneManager.GetActiveScene().name == mainSceneName) {
            foreach (var unit in debugUnits) {
                unit.AddPerformedEvent(mainSceneName);
            }
        }
    }

    [Serializable]
    class DebugUnit {
        [SerializeField] string name;
        [SerializeField, Tooltip("全てのシーンで利用可能か")] bool isAvailableInAllScenes;
        [SerializeField] InputActionReference inputAction;
        [SerializeField] UnityEvent<InputAction.CallbackContext> action;

        /// <summary>
        /// InputActionにイベント追加
        /// </summary>
        public void AddPerformedEvent(string mainSceneName)
        {
            // メインシーンのみで利用可能だった場合、
            // 現在のシーンがメインシーンじゃなかったら、リターン
            if (!isAvailableInAllScenes) {
                if (SceneManager.GetActiveScene().name != mainSceneName) {
                    return;
                }
            }

            if (inputAction != null) {
                inputAction.ToInputAction().performed += action.Invoke;

                inputAction.asset.Enable();
            }
        }
    }
}


#endif