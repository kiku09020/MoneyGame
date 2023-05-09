using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[����ʏ�Ƀf�o�b�O����\�����邽�߂̃N���X
/// </summary>
public class DebugOnGUI : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] DebugManager manager;

	[Header("Parameters")]
	[SerializeField] int buttonFontSize = 16;							// �{�^�����̃e�L�X�g�̃t�H���g�T�C�Y
	[SerializeField] int toolTipFontSize = 12;							// �c�[���`�b�v�̃t�H���g�T�C�Y
	[SerializeField] Rect windowRect = new Rect(0, 0, 400, 600);        // �E�B���h�E��Rect

	//--------------------------------------------------

	private void OnGUI()
	{
		if (!Debug.isDebugBuild) return;

		// �{�^���p�E�B���h�E
		windowRect = GUI.Window(0, windowRect, ButtonWindow, "Buttons");
	}

	// �{�^���E�B���h�E���̃��C�A�E�g�Ȃ�
	void ButtonWindow(int id)
	{
		// �{�^���̍����ύX
		var height = windowRect.height / (manager.DebugUnits.Count + 1);	// �{�^���̃A�N�V�����̐��ɍ��킹�č�������
		var buttonHeight = GUILayout.Height(height);						// ������GUILayoutOption�ɕϊ�

		// �{�^���̃t�H���g�T�C�Y�ύX
		var buttonStyle = new GUIStyle(GUI.skin.button);	
		buttonStyle.fontSize = buttonFontSize;

		// ���X�g�̕������{�^����ǉ�
		foreach(var unit in manager.DebugUnits) {
			var content = new GUIContent(unit.Name, unit.ToolTip);

			if (GUILayout.Button(content, buttonStyle, buttonHeight)) {		// �{�^��
				unit.DoAction();
			}
		}

		ButtonToolTip();		// �{�^���̐����\��

		GUI.DragWindow();		// �E�B���h�E���h���b�O�\�ɂ���
	}

	void ButtonToolTip()
	{
		// �c�[���`�b�v�̃t�H���g�T�C�Y�ύX
		var toolTipStyle = new GUIStyle(GUI.skin.label);
		toolTipStyle.fontSize = toolTipFontSize;

		GUILayout.Label(GUI.tooltip, toolTipStyle);
	}
}
