using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIGroupBase : MonoBehaviour
{
    public abstract void Initialize();

    /// <summary>
    /// UI‚ð”ñ•\Ž¦‚É‚·‚é
    /// </summary>
    public virtual void Hide() => gameObject.SetActive(false);

    /// <summary>
    /// UI‚ð•\Ž¦‚·‚é
    /// </summary>
    public virtual void Show() => gameObject.SetActive(true);
}
