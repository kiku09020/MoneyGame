using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using MyEditor;
using static MyEditor.EditorTemplate.Direction;

namespace Test {
    [CustomEditor(typeof(InsTest))]
    public class InspectorEditorTest : Editor {

        bool toggle;

        //--------------------------------------------------

        void Awake()
        {

        }

		public override void OnInspectorGUI()
		{
            base.OnInspectorGUI();  

            var targ = target as InsTest;

            targ.HP = EditorGUILayout.IntField("HP", targ.HP);

            // ��\���O���[�v
            toggle = EditorTemplate.Group.ToggleGroup(toggle, "Buttons", horizontal, () => {

                var buttonSize = 50;

                // ���Z�b�g�{�^��
                EditorTemplate.ColorTemp.ChangeBGColor(Color.black, () => {
                    EditorTemplate.Button.BasicButton(new GUIContent("Reset", "Reset HP"), () => targ.HP = 0,
                                                        GUILayout.Width(buttonSize), GUILayout.Height(buttonSize));
                });

                // �񕜃{�^��
                EditorTemplate.ColorTemp.ChangeBGColor(Color.red, () => {
                    EditorTemplate.Button.BasicButton(new GUIContent("Set Max"), () => targ.HP = 100,
                                                        GUILayout.Width(buttonSize), GUILayout.Height(buttonSize));
                });
            });
		}
	}
}