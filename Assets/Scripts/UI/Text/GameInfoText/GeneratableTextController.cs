using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.TextController {
    public abstract class GeneratableTextController : TextController_Base {

        [Header("Parameters")]
        [SerializeField,Tooltip("生成遅延時間")] float generationDelay; 

        //--------------------------------------------------

        /// <summary>
        /// テキストを変更
        /// </summary>
        protected abstract string SetMessage(float value);

		//--------------------------------------------------

		/// <summary>
		/// テキストの生成
		/// </summary>
		public async UniTask GenerateText(float value)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(generationDelay));

            text.text = SetMessage(value);

            Instantiate(text, transform);       // 生成
        }

        /// <summary>
        /// テキストの生成後にすべてのアニメーションを再生
        /// </summary>
        public async void GenerateAndPlayAllAnimation(float value)
        {
            await GenerateText(value);

            PlayAllAnimations();
        }
    }
}