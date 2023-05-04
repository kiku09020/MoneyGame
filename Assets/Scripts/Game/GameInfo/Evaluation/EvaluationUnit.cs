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
	/// �]�����b�Z�[�W
	/// </summary>
	public string Message => message;

	/// <summary>
	/// �]�����b�Z�[�W�̃e�L�X�g�̐F
	/// </summary>
	public Color MessageColor => messageColor;

	/// <summary>
	/// �]���^�C�v
	/// </summary>
	public EvaluationManager.EvaluationType EvalType => type;
}
