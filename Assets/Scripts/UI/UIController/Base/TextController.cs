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
        /// �e�L�X�g�̕�������w�肵�ĕԂ�
        /// </summary>
        public virtual void SetTextMessage(float value) { }

        public void SetText(string text)
        {
            this.uiObject.text = text;
        }

		//--------------------------------------------------

		/// <summary>
		/// �e�L�X�g���Z�b�g��ɁA�A�j���[�V�������Đ�
		/// </summary>
		public void SetAndPlayAnimation(float value)
        {
            SetTextMessage(value);

            PlayAnimation();
        }

		/// <summary>
		/// �e�L�X�g���Z�b�g��ɁA�A�j���[�V�������Đ�
		/// </summary>
		public void SetAndPlayAnimation(string text)
        {
            SetText(text);
            PlayAnimation();
        }

        //--------------------------------------------------
    }
}