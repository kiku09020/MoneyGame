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
        // デバッグビルド以外は早期リターン
        if (!Debug.isDebugBuild) return;

        foreach (var unit in debugUnits) {
            unit.AddPerformedEvent();
        }
    }

	//--------------------------------------------------

	[Serializable]
    public class DebugUnit {
        [SerializeField] string name;
        [SerializeField,Tooltip("ボタン用のツールチップ")] string toolTip;
        [SerializeField,Tooltip("GUIの種類")] GUITypeEnum guiType;

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
        /// InputActionにイベント追加
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
