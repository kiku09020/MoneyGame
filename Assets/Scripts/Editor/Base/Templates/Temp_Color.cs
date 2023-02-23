using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MyEditor {
	public partial class EditorTemplate : Editor {
		public class ColorTemp {
			static readonly Color defaultColor = GUI.color;					// デフォルトの色
			static readonly Color defaultBGColor = GUI.backgroundColor;     // デフォルトの背景色
			static readonly Color defaultContentColor = GUI.contentColor;   // デフォルトのコンテンツ色

			/// <summary>
			/// UIの全体の色を変更
			/// </summary>
			public static void ChangeColor(Color color,Action action)
			{
				GUI.color = color;
				action?.Invoke();
				GUI.color = defaultColor;
			}

			/// <summary>
			/// UIの背景色を変更
			/// </summary>
			/// <remarks>ex:ボタンのボタン部分など</remarks>
			public static void ChangeBGColor(Color color,Action action)
			{
				GUI.backgroundColor = color;
				action?.Invoke();
				GUI.backgroundColor = defaultBGColor;
			}

			/// <summary>
			/// UIのコンテンツ色を変更
			/// </summary>
			/// <remarks>ex:ボタンの文字部分など</remarks>
			public static void ChangeContentColor(Color color,Action action)
			{
				GUI.contentColor = color;
				action?.Invoke();
				GUI.contentColor = defaultContentColor;
			}
		}
	}
}
