using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class DebugManager : MonoBehaviour {
    [SerializeField] List<DebugUnit> debugUnits = new List<DebugUnit>();

    public List<DebugUnit> DebugUnits => debugUnits;

    protected void Awake()
    {
        // �f�o�b�O�r���h�ȊO�͑������^�[��
        if (!Debug.isDebugBuild) return;

        foreach (var unit in debugUnits) {
            unit.AddPerformedEvent();
        }
    }

	//--------------------------------------------------

	[Serializable]
    public class DebugUnit {
        [SerializeField] string name;
        [SerializeField,Tooltip("�{�^���p�̃c�[���`�b�v")] string toolTip;
        [SerializeField,Tooltip("GUI�̎��")] GUITypeEnum guiType;

        [SerializeField] InputActionReference inputAction;
        [SerializeField] UnityEvent<InputAction.CallbackContext> action;

        [HideInInspector] public bool value;
        [HideInInspector] public bool toggleValue;

        public string Name => name;
        public string ToolTip => toolTip;
        public GUITypeEnum GUIType => guiType;

        public enum GUITypeEnum
        {
            button,
            toggle,
        }

		//--------------------------------------------------

		public void DoAction()
        {
            action?.Invoke(default);
        }

        /// <summary>
        /// InputAction�ɃC�x���g�ǉ�
        /// </summary>
        public void AddPerformedEvent()
        {
            if (inputAction != null) {
                inputAction.ToInputAction().performed += action.Invoke;

                inputAction.asset.Enable();
            }
        }
    }
}
