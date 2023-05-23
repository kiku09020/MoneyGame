using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIController<T> : MonoBehaviour where T : ILayoutElement
{
    [SerializeField] protected T uiObject;

    [SerializeField] protected UIAnimData animData;

    //--------------------------------------------------

    /// <summary>
    /// UIを表示、非表示
    /// </summary>
    /// <param name="activate"></param>
    abstract public void SetUIActivate(bool activate);

    /// <summary>
    /// アニメーションを再生
    /// </summary>
    protected void PlayAnimation()
    {
        if (uiObject != null && animData != null) {
            UIAnimator<T>.Play(uiObject, animData);
        }
    }
}
