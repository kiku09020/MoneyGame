using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameController.UI.UIController {
    public abstract class UIController<T,Anim> : MonoBehaviour where T : ILayoutElement where Anim:UIAnimData {
        [SerializeField] protected T uiObject;

        [SerializeField] protected Anim animData;

        //--------------------------------------------------

        /// <summary>
        /// UI��\���A��\��
        /// </summary>
        /// <param name="activate"></param>
        abstract public void SetUIActivate(bool activate);

        /// <summary>
        /// �A�j���[�V�������Đ�
        /// </summary>
        public void PlayAnimation()
        {
            if (uiObject != null && animData != null) {
                UIAnimator<T>.Play(uiObject, animData);
            }
        }
    }
}