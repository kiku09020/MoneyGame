using Game.Money.MoneyManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public abstract class EvaluationUnit:MonoBehaviour {
	[Header("Messages")]
	[SerializeField,Tooltip("�]�����b�Z�[�W")]		protected string message;
	[SerializeField,Tooltip("�]�����b�Z�[�W�̐F")]	protected Color messageColor;

	[Header("SubEvents")]
	[SerializeField,Tooltip("�T�u�C�x���g")] UnityEvent subEvent;

	[Header("Components")]
	[SerializeField] protected WholeMoneyInfo moneyInfo;

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

	//--------------------------------------------------

	/// <summary>
	/// �T�u�C�x���g�B�X�N���v�g����ǉ��������ꍇ�ɗ��p����
	/// </summary>
	public event EventHandler EvaluateSubEvent;

	/// <summary>
	/// �]���̏���
	/// </summary>
	protected virtual bool Condition(){ return true; }

	/// <summary>
	/// �]��
	/// </summary>
	public void Evaluate()
	{
		if (Condition()) {
			CommonAction();		// ���s

			// �T�u�C�x���g�Q�����s
			EvaluateSubEvent?.Invoke(this, EventArgs.Empty);
			subEvent?.Invoke();
		}
	}

	//--------------------------------------------------

	/// <summary>
	/// ���ʏ���
	/// </summary>
	void CommonAction()
	{

	}

	public void Exit()
	{

	}
}
