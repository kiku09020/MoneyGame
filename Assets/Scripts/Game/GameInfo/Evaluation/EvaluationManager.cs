using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EvaluationUnitList",menuName ="ScriptableObject/EvaluationUnitList")]
public class EvaluationManager:ScriptableObject {

	[Header("Evaluate")]
	[SerializeField] List<EvaluationUnit> evaluationMessages = new List<EvaluationUnit>();

	/// <summary>
	/// �]���^�C�v
	/// </summary>
	public enum EvaluationType {
		Perfect,
		Normal,
		Missed,
		Over,
	}

	//--------------------------------------------------

	/// <summary>
	/// �w�肵���]���̃��b�Z�[�W���擾����
	/// </summary>
	/// <param name="type">�ړI�̕]���^�C�v</param>
	/// <returns>�w�肳�ꂽ�]���̃��b�Z�[�W</returns>
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


