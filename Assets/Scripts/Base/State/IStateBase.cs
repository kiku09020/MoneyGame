using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IStateBase
{
    public string Name { get; }

    /// <summary>
    /// ���̏�ԂɂȂ����u�Ԃ̏���
    /// </summary>
    public UnityEvent EnterEvent { get;  }

    /// <summary>
    /// ���̏�Ԃ̂Ƃ����t���[���Ăяo������
    /// </summary>
    public UnityEvent UpdateEvent { get; }

    /// <summary>
    /// ���̏�Ԃ��甲����u�Ԃ̏���
    /// </summary>
    public UnityEvent ExitEvent { get; }
}
