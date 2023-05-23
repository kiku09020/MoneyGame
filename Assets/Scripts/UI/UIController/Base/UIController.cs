using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIController<T> : MonoBehaviour where T : ILayoutElement
{
    [SerializeField] protected T uiObject;
    [SerializeField] UIAnimator animator;

    //--------------------------------------------------

    /// <summary>
    /// UIÇï\é¶ÅAîÒï\é¶
    /// </summary>
    /// <param name="activate"></param>
    abstract public void SetUIActivate(bool activate);
}
