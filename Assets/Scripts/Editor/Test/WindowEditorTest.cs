using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using MyEditor;

using static MyEditor.EditorTemplate.Direction;

namespace Test {
    public class WindowEditorTest : WindowEditorBase {

        bool folder;
        bool folder2;

        Vector2 scrollPos;
        Vector2 scroll_2;

        //--------------------------------------------------

        [MenuItem("EditorWindow/Test")]
        static void ShowWindow()
        {
            var window = GetWindow<WindowEditorTest>();
            window.titleContent = new GUIContent("TestWindow","Test");
            
        }

        private void OnGUI()
        {
            // 全体
            EditorTemplate.Group.Grouping(vertical,false,() => {

                // スクロールバー
                scrollPos = EditorTemplate.Group.Scroll(vertical, 500, scrollPos, () => {

                    // グループ
                    EditorTemplate.Group.Grouping(vertical, true, () => {
                        // ラベルグループ(開閉可能)
                        folder = EditorTemplate.Group.Folder(folder, "Group",vertical, () => {


                            EditorGUILayout.LabelField("Label");
                            EditorGUILayout.SelectableLabel("Label2");
                        });

                        // 編集不可グループ
                        EditorTemplate.Group.DisableGroup(() => {
                            EditorGUILayout.ColorField("Color", Color.white);
                            EditorGUILayout.Vector4Field("Vector", Vector4.zero);
                        });
                    });


                });

                // 文字列スクロールグループ
                scroll_2 = EditorTemplate.Group.Scroll(vertical, 100, scroll_2, () => {
                    for (int i = 0; i < 20; i++) {
                        EditorGUILayout.LabelField($"{i}番目！！");
                    }
                });
            });


        }
    }
}
