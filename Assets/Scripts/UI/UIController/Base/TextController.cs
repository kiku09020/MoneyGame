using System;
using TMPro;
using UnityEngine;

namespace GameController.UI.UIController {
    public abstract class TextController<Anim> : UIController<TextMeshProUGUI,Anim> where Anim:UIAnimData {

        //--------------------------------------------------
        protected virtual void Awake()
        {
            SetUIActivate(false);
        }

        public override void SetUIActivate(bool activate)
        {
            uiObject.gameObject.SetActive(activate);
        }

        //--------------------------------------------------

        /// <summary>
        /// テキストの文字列を指定して返す
        /// </summary>
        public virtual void SetText<T>(T value)where T:IConvertible { }

        public void SetText(string text)
        {
            uiObject.text = text;
        }

		//--------------------------------------------------

		/// <summary>
		/// テキストをセット後に、アニメーションを再生
		/// </summary>
		public void SetAndPlayAnimation(float value)
        {
            SetText(value);

            PlayAnimation();
        }

		/// <summary>
		/// テキストをセット後に、アニメーションを再生
		/// </summary>
		public void SetAndPlayAnimation(string text)
        {
            SetText(text);
            PlayAnimation();
        }

        //--------------------------------------------------
    }
}