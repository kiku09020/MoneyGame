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
        /// UIを表示、非表示
        /// </summary>
        /// <param name="activate"></param>
        abstract public void SetUIActivate(bool activate);

        /// <summary>
        /// アニメーションを再生
        /// </summary>
        public void PlayAnimation()
        {
            var targetAnim = anims[0];

            if (uiObject != null && targetAnim != null) {
                UIAnimator<T>.Play(uiObject, targetAnim);       // アニメーション再生
            }
        }

        /// <summary>
        /// アニメーションデータを指定して再生
        /// </summary>
        /// <param name="animation"></param>
        public void PlayAnimation(string animationName)
        {
            foreach(var anim in anims) {

                // 指定した名前のアニメーションがあれば、再生
                if(anim.name == animationName) {
                    UIAnimator<T>.Play(uiObject, anim);
                    break;
                }
            }
        }
    }
}