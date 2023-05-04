using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EvaluationUnit {
	[SerializeField] string name;
	[SerializeField] string message;
	[SerializeField] Color messageColor;
	[SerializeField] EvaluationManager.EvaluationType type;

	//--------------------------------------------------
	// Properties
	/// <summary>
	/// 評価メッセージ
	/// </summary>
	public string Message => message;

	/// <summary>
	/// 評価メッセージのテキストの色
	/// </summary>
	public Color MessageColor => messageColor;

	/// <summary>
	/// 評価タイプ
	/// </summary>
	public EvaluationManager.EvaluationType EvalType => type;
}
