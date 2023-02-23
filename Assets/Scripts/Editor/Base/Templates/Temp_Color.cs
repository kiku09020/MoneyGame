using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MyEditor {
	public partial class EditorTemplate : Editor {
		public class ColorTemp {
			static readonly Color defaultColor = GUI.color;					// �f�t�H���g�̐F
			static readonly Color defaultBGColor = GUI.backgroundColor;     // �f�t�H���g�̔w�i�F
			static readonly Color defaultContentColor = GUI.contentColor;   // �f�t�H���g�̃R���e���c�F

			/// <summary>
			/// UI�̑S�̂̐F��ύX
			/// </summary>
			public static void ChangeColor(Color color,Action action)
			{
				GUI.color = color;
				action?.Invoke();
				GUI.color = defaultColor;
			}

			/// <summary>
			/// UI�̔w�i�F��ύX
			/// </summary>
			/// <remarks>ex:�{�^���̃{�^�������Ȃ�</remarks>
			public static void ChangeBGColor(Color color,Action action)
			{
				GUI.backgroundColor = color;
				action?.Invoke();
				GUI.backgroundColor = defaultBGColor;
			}

			/// <summary>
			/// UI�̃R���e���c�F��ύX
			/// </summary>
			/// <remarks>ex:�{�^���̕��������Ȃ�</remarks>
			public static void ChangeContentColor(Color color,Action action)
			{
				GUI.contentColor = color;
				action?.Invoke();
				GUI.contentColor = defaultContentColor;
			}
		}
	}
}
