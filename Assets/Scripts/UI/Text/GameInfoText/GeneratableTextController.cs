using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.TextController {
    public abstract class GeneratableTextController : TextController_Base {

        [Header("Parameters")]
        [SerializeField,Tooltip("�����x������")] float generationDelay; 

        //--------------------------------------------------

        /// <summary>
        /// �e�L�X�g��ύX
        /// </summary>
        protected abstract string SetMessage(float value);

		//--------------------------------------------------

		/// <summary>
		/// �e�L�X�g�̐���
		/// </summary>
		public async UniTask GenerateText(float value)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(generationDelay));

            text.text = SetMessage(value);

            Instantiate(text, transform);       // ����
        }

        /// <summary>
        /// �e�L�X�g�̐�����ɂ��ׂẴA�j���[�V�������Đ�
        /// </summary>
        public async void GenerateAndPlayAllAnimation(float value)
        {
            await GenerateText(value);

            PlayAllAnimations();
        }
    }
}