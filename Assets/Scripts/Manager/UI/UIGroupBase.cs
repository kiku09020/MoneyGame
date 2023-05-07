using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIGroupBase : MonoBehaviour
{
    /// <summary>
    /// UI‚Ì‰Šú‰»
    /// </summary>
    public virtual void Initialize() { }

    /// <summary>
    /// UI‚ğ”ñ•\¦‚É‚·‚é
    /// </summary>
    public virtual void Hide() => gameObject.SetActive(false);

    /// <summary>
    /// UI‚ğ•\¦‚·‚é
    /// </summary>
    public virtual void Show() => gameObject.SetActive(true);
}
