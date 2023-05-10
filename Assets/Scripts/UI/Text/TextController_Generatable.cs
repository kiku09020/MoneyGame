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
		/// 生成後に表示する
		/// </summary>
		public async void GenerateAndDispText(object value)
		{
			// 遅延待機
			await UniTask.Delay(TimeSpan.FromSeconds(textParameter.delay), false, PlayerLoopTiming.FixedUpdate, token);

			var textObj = Instantiate(text, transform);

			textObj.gameObject.SetActive(true);

			var message = SetMessage(value);

			DispText(textObj, message, () => {

				// 終了時に破棄
				if (destroyable) {
					Destroy(textObj.gameObject);
				}
			});
		}

		/// <summary>
		/// 生成後に表示する(文字色指定可能)
		/// </summary>
		public async void GenerateAndDispText(object value, Color color)
		{
			// 遅延待機
			await UniTask.Delay(TimeSpan.FromSeconds(textParameter.delay), false, PlayerLoopTiming.FixedUpdate, token);

			textParameter.targetColor = color;

			var obj = Instantiate(text, transform);

			obj.gameObject.SetActive(true);

			var message = SetMessage(value);

			DispText(obj, message, () => {

				// 終了時に破棄
				if (destroyable) {
					Destroy(obj.gameObject);
				}
			});
		}

		/// <summary>
		/// テキストメッセージの指定
		/// </summary>
		protected virtual string SetMessage(object value)
		{
			return $"{value.ToString()}";
		}
	}
}