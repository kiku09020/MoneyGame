using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameController.UI.UIController {
    public abstract class UIController<T,Anim> : MonoBehaviour where T : ILayoutElement where Anim:UIAnimData {
        [SerializeField] protected T uiObject;

        [SerializeField] protected List<Anim> anims = new List<Anim>();

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
            var targetAnim = anims[0];

            if (uiObject != null && targetAnim != null) {
                UIAnimator<T>.Play(uiObject, targetAnim);       // �A�j���[�V�����Đ�
            }
        }

        /// <summary>
        /// �A�j���[�V�����f�[�^���w�肵�čĐ�
        /// </summary>
        /// <param name="animation"></param>
        public void PlayAnimation(string animationName)
        {
            foreach(var anim in anims) {

                // �w�肵�����O�̃A�j���[�V����������΁A�Đ�
                if(anim.name == animationName) {
                    UIAnimator<T>.Play(uiObject, anim);
                    break;
                }
            }
        }
    }
}