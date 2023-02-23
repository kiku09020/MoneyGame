using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MyEditor {
    public partial class EditorTemplate : Editor {
        public class Group {
            // グループの方向指定
            static GUI.Scope SetGroupDirection(Direction direction = Direction.vertical, bool isColored = false)
            {
                switch (direction) {
                    case Direction.vertical:
                        return isColored ? new GUILayout.VerticalScope(GUI.skin.box) : new GUILayout.VerticalScope();

                    case Direction.horizontal:
                        return isColored ? new GUILayout.HorizontalScope(GUI.skin.box) : new GUILayout.HorizontalScope();
                }

                return null;
            }

            //--------------------------------------------------

            /// <summary>
            /// グループ化
            /// </summary>
            public static void Grouping(Direction direction, bool isColored, Action action)
            {
                using (SetGroupDirection(direction, isColored)) {
                    action?.Invoke();
                    Space();
                }
            }

            /// <summary>
            /// 開閉できるグループを作成
            /// </summary>
            public static bool Folder(bool folderFlag, string itemName, Direction direction, Action folderAction)
            {
                Grouping(direction, false, () =>
                {
                    folderFlag = EditorGUILayout.BeginFoldoutHeaderGroup(folderFlag, itemName);

                    // 開いている状態のとき、Action実行
                    if (folderFlag) {
                        folderAction?.Invoke();
                    }

                    EditorGUILayout.EndFoldoutHeaderGroup();
                });
                return folderFlag;
            }

            /// <summary>
            ///  有効化、無効化できるグループ
            /// </summary>
            public static bool ToggleGroup(bool toggleFlag,string itemName,Direction direction,Action action)
			{
                using (var group = new EditorGUILayout.ToggleGroupScope(itemName, toggleFlag)) {
                    toggleFlag = group.enabled;

                    Grouping(direction, false, action);
				}

                return toggleFlag;
			}

            /// <summary>
            /// 編集不可にする
            /// </summary>
            public static void DisableGroup(Action action,  Direction direction = Direction.vertical, bool disable = true)
            {
                Grouping(direction, false, () =>
                {
                    EditorGUI.BeginDisabledGroup(disable);
                    action?.Invoke();
                    EditorGUI.EndDisabledGroup();
                });
            }

            /// <summary>
            /// スクロールグループ
            /// </summary>
            public static Vector2 Scroll(Direction direction, float size, Vector2 varPos, Action action)
            {
                GUILayoutOption gui = null;
                switch (direction) {
                    case Direction.vertical: gui = GUILayout.Height(size); break;  // Vertical:Heightを指定
                    case Direction.horizontal: gui = GUILayout.Width(size); break;  // Horizontal:Widthを指定
                }

                using (var scrollView = new EditorGUILayout.ScrollViewScope(varPos, gui)) {
                    action?.Invoke();

                    Line(Color.black);

                    return varPos = scrollView.scrollPosition;
                }
            }
        }
    }
}