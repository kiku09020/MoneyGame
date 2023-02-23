using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MyEditor {
    public partial class EditorTemplate : Editor {
        public class Button {
            /// <summary>
            /// í èÌÇÃÉ{É^Éì
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
        }
    }
}