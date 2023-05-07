using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MyEditor {
    public partial class EditorTemplate : Editor {
        public class Button {
            /// <summary>
            /// 通常のボタン
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
			/// 複数のミニボタン
			/// </summary>
			/// <param name="LButton">左端</param>
			/// <param name="RButton">右端</param>
			/// <param name="midButtons">内側</param>
			public static void MiniButtons(MiniButton LButton, MiniButton RButton, params MiniButton[] midButtons)
			{
				Group.Grouping(Direction.horizontal, false, () => {

					// 左端
					if (LButton != null) {
						if (GUILayout.Button(LButton.content, EditorStyles.miniButtonLeft)) {
							LButton.action?.Invoke();
						}
					}

					// 内側
					foreach (var midButton in midButtons) {
						if (midButton != null) {
							if (GUILayout.Button(midButton.content, EditorStyles.miniButtonMid)) {
								midButton.action?.Invoke();
							}
						}
					}

					// 右端
					if (RButton != null) {
						if (GUILayout.Button(RButton.content, EditorStyles.miniButtonRight)) {
							RButton.action?.Invoke();
						}
					}
				});
			}

			// ミニボタンクラス
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