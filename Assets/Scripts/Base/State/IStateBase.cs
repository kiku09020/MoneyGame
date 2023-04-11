using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IStateBase
{
    public string Name { get; }

    /// <summary>
    /// ‚»‚Ìó‘Ô‚É‚È‚Á‚½uŠÔ‚Ìˆ—
    /// </summary>
    public UnityEvent EnterEvent { get;  }

    /// <summary>
    /// ‚»‚Ìó‘Ô‚Ì‚Æ‚«–ˆƒtƒŒ[ƒ€ŒÄ‚Ño‚·ˆ—
    /// </summary>
    public UnityEvent UpdateEvent { get; }

    /// <summary>
    /// ‚»‚Ìó‘Ô‚©‚ç”²‚¯‚éuŠÔ‚Ìˆ—
    /// </summary>
    public UnityEvent ExitEvent { get; }
}
