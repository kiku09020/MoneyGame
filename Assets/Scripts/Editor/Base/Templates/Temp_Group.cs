using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MyEditor {
    public partial class EditorTemplate : Editor {
        public class Group {
            // �O���[�v�̕����w��
            static GUI.Scope SetGroupDirection(Direction direction = Direction.vertical, bool isColored = false)
            {
                switch (direction) {
                    case Direction.vertical:
                        return isColored ? new EditorGUILayout.VerticalScope(GUI.skin.box) : new EditorGUILayout.VerticalScope();

                    case Direction.horizontal:
                        return isColored ? new EditorGUILayout.HorizontalScope(GUI.skin.box) : new EditorGUILayout.HorizontalScope();
                }

                return null;
            }

            //--------------------------------------------------

            /// <summary>
            /// �O���[�v��
            /// </summary>
            public static void Grouping(Direction direction, bool isColored, Action action)
            {
                using (SetGroupDirection(direction, isColored)) {
                    action?.Invoke();
                    Space();
                }
            }

            /// <summary>
            /// �J�ł���O���[�v���쐬
            /// </summary>
            public static bool Folder(bool folderFlag, string itemName, Direction direction, Action folderAction)
            {
                folderFlag = EditorGUILayout.BeginFoldoutHeaderGroup(folderFlag, itemName);

                using (new EditorGUILayout.HorizontalScope()) {
                    Space(SpaceType.horizontal);
                    Grouping(direction, false, () => {
                        // �J���Ă����Ԃ̂Ƃ��AAction���s
                        if (folderFlag) {
                            folderAction?.Invoke();
                        }
                    });

                }
                    EditorGUILayout.EndFoldoutHeaderGroup();
                return folderFlag;
            }

			/// <summary>
			/// �J�ł���O���[�v���쐬
			/// </summary>
			public static bool OpenableGroup(Direction direction, bool value, string name, Action action, GUIStyle style = null, params GUILayoutOption[] options)
			{
				value = EditorGUILayout.BeginFoldoutHeaderGroup(value, name, style);     // value�K�p

                Grouping(direction, true, () => {
                    if (value) action?.Invoke();       // �J���Ă�����AAction���s
                });

				EditorGUILayout.EndFoldoutHeaderGroup();
				return value;
			}

			/// <summary>
			///  �L�����A�������ł���O���[�v
			/// </summary>
			public static bool ToggleGroup(bool toggleFlag,string itemName,Direction direction,Action action)
			{
                using (var group = new EditorGUILayout.ToggleGroupScope(itemName, toggleFlag)) {
                    using (new EditorGUILayout.HorizontalScope()) {
                        toggleFlag = group.enabled;

                        Space(SpaceType.horizontal);
                        Grouping(direction, false, action);
                    }
                }

                return toggleFlag;
			}

            /// <summary>
            /// �ҏW�s�ɂ���
            /// </summary>
            public static void DisableGroup(Action action, Direction direction = Direction.vertical, bool disable = true)
            {
                Grouping(direction, false, () => {
                    EditorGUI.BeginDisabledGroup(disable);
                    action?.Invoke();
                    EditorGUI.EndDisabledGroup();
                });
            }

            /// <summary>
            /// �X�N���[���O���[�v
            /// </summary>
            public static Vector2 Scroll(Direction direction, float size, Vector2 varPos, Action action)
            {
                GUILayoutOption gui = null;
                switch (direction) {
                    case Direction.vertical: gui = GUILayout.Height(size); break;  // Vertical:Height���w��
                    case Direction.horizontal: gui = GUILayout.Width(size); break;  // Horizontal:Width���w��
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