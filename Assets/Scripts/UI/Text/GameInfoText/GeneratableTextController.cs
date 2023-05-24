using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.UIController {
    public abstract class GeneratableTextController : TextController<GeneratableUIAnimData> {

        [Header("Parameters")]
        [SerializeField,Tooltip("�����x������")] protected float generationDelay;

		//--------------------------------------------------

		/// <summary>
		/// �e�L�X�g�̐���
		/// </summary>
		public async UniTask GenerateText()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(generationDelay));     // �ҋ@

			Instantiate(uiObject, transform);       // ����
		}

		/// <summary>
		/// �e�L�X�g�̎w���ɐ���
		/// </summary>
		public async UniTask GenerateText(float value)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(generationDelay));     // �ҋ@

            SetText(value);                     // �e�L�X�g�w��
            Instantiate(uiObject, transform);       // ����
        }

        /// <summary>
		/// �e�L�X�g�̎w���ɐ���
		/// </summary>
		public async UniTask GenerateText(string text)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(generationDelay));     // �ҋ@

            SetText(text);                          // �e�L�X�g�w��
            Instantiate(uiObject, transform);      // ����
        }

		//--------------------------------------------------

		/// <summary>
		/// ������ɃA�j���[�V�������Đ�
		/// </summary>
		public async void GenerateAndPlayAnimation()
		{
			await GenerateText();
			PlayAnimation();
		}

		/// <summary>
		/// ������ɃA�j���[�V�������Đ�
		/// </summary>
		public async void GenerateAndPlayAnimation(float value)
		{
			await GenerateText(value);
			PlayAnimation();
		}

		/// <summary>
		/// ������ɃA�j���[�V�������Đ�
		/// </summary>
		public async void GenerateAndPlayAnimation(string text)
		{
			await GenerateText(text);
			PlayAnimation();
		}

		//--------------------------------------------------
	}
}