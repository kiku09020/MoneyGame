using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.TextController {
	public class TextController_Generatable : TextController_Base {
		[Header("Parameters")]
		[SerializeField] bool destroyable;

		//--------------------------------------------------

		/// <summary>
		/// ������ɕ\������
		/// </summary>
		public async void GenerateAndDispText(object value)
		{
			// �x���ҋ@
			await UniTask.Delay(TimeSpan.FromSeconds(textParameter.delay), false, PlayerLoopTiming.FixedUpdate, token);

			var textObj = Instantiate(text, transform);

			textObj.gameObject.SetActive(true);

			var message = SetMessage(value);

			DispText(textObj, message, () => {

				// �I�����ɔj��
				if (destroyable) {
					Destroy(textObj.gameObject);
				}
			});
		}

		/// <summary>
		/// ������ɕ\������(�����F�w��\)
		/// </summary>
		public async void GenerateAndDispText(object value, Color color)
		{
			// �x���ҋ@
			await UniTask.Delay(TimeSpan.FromSeconds(textParameter.delay), false, PlayerLoopTiming.FixedUpdate, token);

			textParameter.targetColor = color;

			var obj = Instantiate(text, transform);

			obj.gameObject.SetActive(true);

			var message = SetMessage(value);

			DispText(obj, message, () => {

				// �I�����ɔj��
				if (destroyable) {
					Destroy(obj.gameObject);
				}
			});
		}

		/// <summary>
		/// �e�L�X�g���b�Z�[�W�̎w��
		/// </summary>
		protected virtual string SetMessage(object value)
		{
			return $"{value.ToString()}";
		}
	}
}