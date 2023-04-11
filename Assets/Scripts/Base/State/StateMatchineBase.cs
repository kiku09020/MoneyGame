using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMatchineBase<T> :MonoBehaviour where T: notnull, IStateBase
{
	/// <summary>
	/// ���݂̏��
	/// </summary>
	public T NowState { get; protected set; }

	public List<T> stateList = new List<T>();

	/// <summary>
	/// ��Ԃ̏�����
	/// </summary>
	/// /// <param name="initState">�������</param>
    public void StateInit(int index)
    {
		NowState = CheckList(index);
		NowState.EnterEvent?.Invoke();
    }

	public void StateInit(string name)
	{
		NowState= CheckList(name);
		NowState.EnterEvent?.Invoke();
	}

    /// <summary>
    /// ���݂̏�Ԃ̍X�V����
    /// </summary>
    public void StateUpdate()
	{
		NowState.UpdateEvent?.Invoke();
	}

	/// <summary>
	/// ��ԑJ��
	/// </summary>
	/// <param name="index">��ԃ��X�g�̗v�f�ԍ�</param>
	public void StateTransition(int index)
	{
		NowState.ExitEvent?.Invoke();
		NowState = CheckList(index);
		NowState.EnterEvent?.Invoke();
	}

	public void StateTransition(string name)
	{
		NowState.ExitEvent?.Invoke();
		NowState = CheckList(name);
		NowState.EnterEvent?.Invoke();
	}

	// ���X�g�Ɏw�肳�ꂽ�v�f�ԍ��̗v�f�����邩�ǂ����B����΂��̗v�f�ԍ��̏�Ԃ�Ԃ�
	T CheckList(int index)
	{
		if (0 <= index && index < stateList.Count) {
			return stateList[index];
		}

		throw new System.Exception("���݂��Ȃ��v�f�ԍ����w�肳��܂���");
	}

	// ���X�g���Ɏw�肳�ꂽ���O�̗v�f�����邩�ǂ����B����΂��̖��O�̏�Ԃ�Ԃ�
	T CheckList(string name)
	{
		foreach(var state in stateList) {
			if (state.Name == name) {
				return state;
			}
		}

		throw new System.Exception("�w�肳�ꂽ���O�̗v�f�͂���܂���B");
	}
}
