using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MyEditor {
    public partial class EditorTemplate : Editor {
        public class Button {
            /// <summary>
            /// �ʏ�̃{�^��
            /// </summary>
            public static void BasicButton(GUIContent content, Action action)
            {
                if (GUILayout.Button(content)) {
                    action?.Invoke();
                }
            }

            public static void BasicButton(GUIContent content,  Action action, params GUILayoutOption[] layout)
			{
                if (GUILayout.Button(content, layout)){
                    action?.Invoke();
				}
			}

			/// <summary>
			/// �����̃~�j�{�^��
			/// </summary>
			/// <param name="LButton">���[</param>
			/// <param name="RButton">�E�[</param>
			/// <param name="midButtons">����</param>
			public static void MiniButtons(MiniButton LButton, MiniButton RButton, params MiniButton[] midButtons)
			{
				Group.Grouping(Direction.horizontal, false, () => {

					// ���[
					if (LButton != null) {
						if (GUILayout.Button(LButton.content, EditorStyles.miniButtonLeft)) {
							LButton.action?.Invoke();
						}
					}

					// ����
					foreach (var midButton in midButtons) {
						if (midButton != null) {
							if (GUILayout.Button(midButton.content, EditorStyles.miniButtonMid)) {
								midButton.action?.Invoke();
							}
						}
					}

					// �E�[
					if (RButton != null) {
						if (GUILayout.Button(RButton.content, EditorStyles.miniButtonRight)) {
							RButton.action?.Invoke();
						}
					}
				});
			}

			// �~�j�{�^���N���X
			public class MiniButton {
				public GUIContent content;
				public Action action;

				public MiniButton(GUIContent content, Action action)
				{
					this.content = content;
					this.action = action;
				}
			}
		}
    }
}