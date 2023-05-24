using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

namespace GameController.UI.UIController {
    public class GeneratableTextController : TextController<GeneratableUIAnimData> {

        [Header("Parameters")]
        [SerializeField,Tooltip("�����x������")]	protected float generationDelay;
		[SerializeField, Tooltip("�\������")]		protected float dispDuration = 3;

		[SerializeField, Tooltip("�����ʒu")] protected Vector2 generatedPosition = Vector3.zero;

		//--------------------------------------------------

		CancellationToken token;

		protected override void Awake()
		{
			token = this.GetCancellationTokenOnDestroy();

			SetUIActivate(true);
		}

		/// <summary>
		/// �e�L�X�g�̐���
		/// </summary>
		public async UniTask<TextMeshProUGUI> GenerateText()
		{
			await Delay(generationDelay);

			return Generate_Base();
		}

		/// <summary>
		/// �e�L�X�g�̎w���ɐ���
		/// </summary>
		public async UniTask<TextMeshProUGUI> GenerateText(float value)
        {
			await Delay(generationDelay);

            SetText(value);                                 // �e�L�X�g�w��
			return Generate_Base();
		}

		/// <summary>
		/// �e�L�X�g�̎w���ɐ���
		/// </summary>
		public async UniTask<TextMeshProUGUI> GenerateText(string text)
        {
			await Delay(generationDelay);

            SetText(text);                                  // �e�L�X�g�w��
			return Generate_Base();
		}

		//--------------------------------------------------

		/// <summary>
		/// ������ɃA�j���[�V�������Đ�
		/// </summary>
		public async void GenerateAndPlayAnimation()
		{
			var obj = await GenerateText();
			PlayAnimation();

			await DestroyUI(obj);
		}

		/// <summary>
		/// ������ɃA�j���[�V�������Đ�
		/// </summary>
		public async void GenerateAndPlayAnimation(float value)
		{
			var obj = await GenerateText(value);
			PlayAnimation();

			await DestroyUI(obj);
		}

		/// <summary>
		/// ������ɃA�j���[�V�������Đ�
		/// </summary>
		public async void GenerateAndPlayAnimation(string text)
		{
			var obj = await GenerateText(text);
			PlayAnimation();

			await DestroyUI(obj);
		}

		//--------------------------------------------------

		// �ҋ@
		async UniTask Delay(float duration)
		{
			await UniTask.Delay(TimeSpan.FromSeconds(duration), cancellationToken: token);
		}

		//--------------------------------------------------

		// ������b���\�b�h
		TextMeshProUGUI Generate_Base()
		{
			var obj = Instantiate(uiObject, transform);     // ����

			obj.rectTransform.anchoredPosition = generatedPosition;		// �ʒu�w��

			return obj;
		}

		// �\�����Ԃ��߂�����폜
		async UniTask DestroyUI(TextMeshProUGUI text)
		{
			await Delay(dispDuration);

			Destroy(text.gameObject);
		}
	}
}