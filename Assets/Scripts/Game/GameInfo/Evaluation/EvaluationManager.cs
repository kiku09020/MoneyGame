using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EvaluationUnitList",menuName ="ScriptableObject/EvaluationUnitList")]
public class EvaluationManager:ScriptableObject {

	[Header("Evaluate")]
	[SerializeField] List<EvaluationUnit> evaluationMessages = new List<EvaluationUnit>();

	/// <summary>
	/// 評価タイプ
	/// </summary>
	public enum EvaluationType {
		Perfect,
		Normal,
		Missed,
		Over,
	}

	//--------------------------------------------------

	/// <summary>
	/// 指定した評価のメッセージを取得する
	/// </summary>
	/// <param name="type">目的の評価タイプ</param>
	/// <returns>指定された評価のメッセージ</returns>
	public EvaluationUnit GetEvaluateMessage(EvaluationType type)
	{
		foreach (var evalUnit in evaluationMessages) {
			if (evalUnit.EvalType == type) {
				return evalUnit;
			}
		}

		return null;
	}

	public EvaluationUnit GetEvaluationUnit<T>() where T : EvaluationUnit 
	{
		foreach(var evalUnit in evaluationMessages) {
			if (evalUnit.GetType() is T) {
				return evalUnit;
			}
		}

		return null;
	}
}


