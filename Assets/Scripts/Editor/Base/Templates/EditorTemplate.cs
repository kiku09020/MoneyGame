using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MyEditor {
    public partial class EditorTemplate : Editor {
        #region Space
        // Space Size
        static readonly float verSpaceSize = 10;        // 縦のスペースサイズ
        static readonly float horSpaceSize = 15;        // 横のスペースサイズ

        /// <summary>
        /// スペースの種類
        /// </summary>
        public enum SpaceType {
            vertical,
            horizontal,
            flexible,
        }
        #endregion

        /// <summary>
        /// 方向
        /// </summary>
        public enum Direction {
            vertical,
            horizontal,
        }
        //-------------------------------------------
        #region Insert

        /// <summary>
        /// スペースを挿入
        /// </summary>
        public static void Space(SpaceType type = SpaceType.flexible)
        {
            switch (type) {
                case SpaceType.vertical: GUILayout.Space(verSpaceSize); break;
                case SpaceType.horizontal: GUILayout.Space(horSpaceSize); break;
                case SpaceType.flexible: GUILayout.FlexibleSpace(); break;
            }
        }

        /// <summary>
        /// ラインを挿入
        /// </summary>
        public static void Line(Color color, float thickness = 3)
        {
            ColorTemp.ChangeColor(color, () => {
                GUILayout.Box("", GUILayout.Height(thickness), GUILayout.ExpandWidth(true));
            });
        }
        #endregion
    }
}