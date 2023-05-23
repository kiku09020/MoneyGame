using TMPro;
using UnityEngine;

namespace GameController.UI.TextController {
    public abstract class TextController : UIController<TextMeshProUGUI> {

        //--------------------------------------------------
        void Awake()
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
        public virtual void SetTextMessage(float value) { }

        public void SetText(string text)
        {
            this.uiObject.text = text;
        }

		//--------------------------------------------------

		/// <summary>
		/// テキストをセット後に、アニメーションを再生
		/// </summary>
		public void SetAndPlayAnimation(float value)
        {
            SetTextMessage(value);

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