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
        // �f�o�b�O�r���h�ȊO�͑������^�[��
        if (!Debug.isDebugBuild) return;

        // ���C���V�[���ł̂ݎ��s
        if (SceneManager.GetActiveScene().name == mainSceneName) {
            foreach (var unit in debugUnits) {
                unit.AddPerformedEvent(mainSceneName);
            }
        }
    }

    [Serializable]
    class DebugUnit {
        [SerializeField] string name;
        [SerializeField, Tooltip("�S�ẴV�[���ŗ��p�\��")] bool isAvailableInAllScenes;
        [SerializeField] InputActionReference inputAction;
        [SerializeField] UnityEvent<InputAction.CallbackContext> action;

        /// <summary>
        /// InputAction�ɃC�x���g�ǉ�
        /// </summary>
        public void AddPerformedEvent(string mainSceneName)
        {
            // ���C���V�[���݂̂ŗ��p�\�������ꍇ�A
            // ���݂̃V�[�������C���V�[������Ȃ�������A���^�[��
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