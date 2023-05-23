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
    /// UI��\���A��\��
    /// </summary>
    /// <param name="activate"></param>
    abstract public void SetUIActivate(bool activate);

    /// <summary>
    /// �A�j���[�V�������Đ�
    /// </summary>
    protected void PlayAnimation()
    {
        if (uiObject != null && animData != null) {
            UIAnimator<T>.Play(uiObject, animData);
        }
    }
}
