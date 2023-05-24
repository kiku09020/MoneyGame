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
        [SerializeField,Tooltip("生成遅延時間")]	protected float generationDelay;
		[SerializeField, Tooltip("表示時間")]		protected float dispDuration = 3;

		[SerializeField, Tooltip("生成位置")] protected Vector2 generatedPosition = Vector3.zero;

		//--------------------------------------------------

		CancellationToken token;

		protected override void Awake()
		{
			token = this.GetCancellationTokenOnDestroy();

			SetUIActivate(true);
		}

		/// <summary>
		/// テキストの生成
		/// </summary>
		public async UniTask<TextMeshProUGUI> GenerateText()
		{
			await Delay(generationDelay);

			return Generate_Base();
		}

		/// <summary>
		/// テキストの指定後に生成
		/// </summary>
		public async UniTask<TextMeshProUGUI> GenerateText(float value)
        {
			await Delay(generationDelay);

            SetText(value);                                 // テキスト指定
			return Generate_Base();
		}

		/// <summary>
		/// テキストの指定後に生成
		/// </summary>
		public async UniTask<TextMeshProUGUI> GenerateText(string text)
        {
			await Delay(generationDelay);

            SetText(text);                                  // テキスト指定
			return Generate_Base();
		}

		//--------------------------------------------------

		/// <summary>
		/// 生成後にアニメーションを再生
		/// </summary>
		public async void GenerateAndPlayAnimation()
		{
			var obj = await GenerateText();
			PlayAnimation();

			await DestroyUI(obj);
		}

		/// <summary>
		/// 生成後にアニメーションを再生
		/// </summary>
		public async void GenerateAndPlayAnimation(float value)
		{
			var obj = await GenerateText(value);
			PlayAnimation();

			await DestroyUI(obj);
		}

		/// <summary>
		/// 生成後にアニメーションを再生
		/// </summary>
		public async void GenerateAndPlayAnimation(string text)
		{
			var obj = await GenerateText(text);
			PlayAnimation();

			await DestroyUI(obj);
		}

		//--------------------------------------------------

		// 待機
		async UniTask Delay(float duration)
		{
			await UniTask.Delay(TimeSpan.FromSeconds(duration), cancellationToken: token);
		}

		//--------------------------------------------------

		// 生成基礎メソッド
		TextMeshProUGUI Generate_Base()
		{
			var obj = Instantiate(uiObject, transform);     // 生成

			obj.rectTransform.anchoredPosition = generatedPosition;		// 位置指定

			return obj;
		}

		// 表示時間を過ぎたら削除
		async UniTask DestroyUI(TextMeshProUGUI text)
		{
			await Delay(dispDuration);

			Destroy(text.gameObject);
		}
	}
}