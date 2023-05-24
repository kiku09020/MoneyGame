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
        /// �e�L�X�g�̕�������w�肵�ĕԂ�
        /// </summary>
        public virtual void SetText<T>(T value)where T:IConvertible { }

        public void SetText(string text)
        {
            uiObject.text = text;
        }

		//--------------------------------------------------

		/// <summary>
		/// �e�L�X�g���Z�b�g��ɁA�A�j���[�V�������Đ�
		/// </summary>
		public void SetAndPlayAnimation(float value)
        {
            SetText(value);

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