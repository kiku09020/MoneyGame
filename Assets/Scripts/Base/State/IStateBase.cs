using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IStateBase
{
    public string Name { get; }

    /// <summary>
    /// その状態になった瞬間の処理
    /// </summary>
    public UnityEvent EnterEvent { get;  }

    /// <summary>
    /// その状態のとき毎フレーム呼び出す処理
    /// </summary>
    public UnityEvent UpdateEvent { get; }

    /// <summary>
    /// その状態から抜ける瞬間の処理
    /// </summary>
    public UnityEvent ExitEvent { get; }
}
