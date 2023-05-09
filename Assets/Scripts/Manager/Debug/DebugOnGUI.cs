using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム画面上にデバッグ情報を表示するためのクラス
/// </summary>
public class DebugOnGUI : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] DebugManager manager;

	[Header("Parameters")]
	[SerializeField] int buttonFontSize = 16;							// ボタン内のテキストのフォントサイズ
	[SerializeField] int toolTipFontSize = 12;							// ツールチップのフォントサイズ
	[SerializeField] Rect windowRect = new Rect(0, 0, 400, 600);        // ウィンドウのRect

	//--------------------------------------------------

	private void OnGUI()
	{
		if (!Debug.isDebugBuild) return;

		// ボタン用ウィンドウ
		windowRect = GUI.Window(0, windowRect, ButtonWindow, "Buttons");
	}

	// ボタンウィンドウ内のレイアウトなど
	void ButtonWindow(int id)
	{
		// ボタンの高さ変更
		var height = windowRect.height / (manager.DebugUnits.Count + 1);	// ボタンのアクションの数に合わせて高さ調節
		var buttonHeight = GUILayout.Height(height);						// 高さをGUILayoutOptionに変換

		// ボタンのフォントサイズ変更
		var buttonStyle = new GUIStyle(GUI.skin.button);	
		buttonStyle.fontSize = buttonFontSize;

		// リストの分だけボタンを追加
		foreach(var unit in manager.DebugUnits) {
			var content = new GUIContent(unit.Name, unit.ToolTip);

			if (GUILayout.Button(content, buttonStyle, buttonHeight)) {		// ボタン
				unit.DoAction();
			}
		}

		ButtonToolTip();		// ボタンの説明表示

		GUI.DragWindow();		// ウィンドウをドラッグ可能にする
	}

	void ButtonToolTip()
	{
		// ツールチップのフォントサイズ変更
		var toolTipStyle = new GUIStyle(GUI.skin.label);
		toolTipStyle.fontSize = toolTipFontSize;

		GUILayout.Label(GUI.tooltip, toolTipStyle);
	}
}
