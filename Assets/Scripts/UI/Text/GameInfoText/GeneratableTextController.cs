using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.UIController {
    public abstract class GeneratableTextController : TextController<GeneratableUIAnimData> {

        [Header("Parameters")]
        [SerializeField,Tooltip("生成遅延時間")] protected float generationDelay;

		//--------------------------------------------------

		/// <summary>
		/// テキストの生成
		/// </summary>
		public async UniTask GenerateText()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(generationDelay));     // 待機

			Instantiate(uiObject, transform);       // 生成
		}

		/// <summary>
		/// テキストの指定後に生成
		/// </summary>
		public async UniTask GenerateText(float value)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(generationDelay));     // 待機

            SetText(value);                     // テキスト指定
            Instantiate(uiObject, transform);       // 生成
        }

        /// <summary>
		/// テキストの指定後に生成
		/// </summary>
		public async UniTask GenerateText(string text)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(generationDelay));     // 待機

            SetText(text);                          // テキスト指定
            Instantiate(uiObject, transform);      // 生成
        }

		//--------------------------------------------------

		/// <summary>
		/// 生成後にアニメーションを再生
		/// </summary>
		public async void GenerateAndPlayAnimation()
		{
			await GenerateText();
			PlayAnimation();
		}

		/// <summary>
		/// 生成後にアニメーションを再生
		/// </summary>
		public async void GenerateAndPlayAnimation(float value)
		{
			await GenerateText(value);
			PlayAnimation();
		}

		/// <summary>
		/// 生成後にアニメーションを再生
		/// </summary>
		public async void GenerateAndPlayAnimation(string text)
		{
			await GenerateText(text);
			PlayAnimation();
		}

		//--------------------------------------------------
	}
}