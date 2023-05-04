using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class TextController_Base : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] protected TextMeshProUGUI text;

	[SerializeField] protected TextControllersParameter textParameter;


	//--------------------------------------------------

	protected CancellationToken token;

	//--------------------------------------------------

	void Awake()
	{
		token = this.GetCancellationTokenOnDestroy();

		// 非表示
		text.gameObject.SetActive(false);
	}

	/// <summary>
	/// テキストの表示(メッセージ指定可能)
	/// </summary>
	public async void DispText(TextMeshProUGUI text, string message = null, Action completeAction = null)
	{
		// 文字変更
		text.text = message;

		// 文字色変更
		if (textParameter.colorable) {
			text.color = textParameter.targetColor;
		}

		// 移動、スケーリング
		if (textParameter.movable) {
			text.rectTransform.DOLocalMove(textParameter.startPosition, 0);		// 初期座標に移動
			text.rectTransform.DOLocalMove(textParameter.targetPosition, textParameter.movingDuration).SetEase(textParameter.movingEaseType);
		}

		if (textParameter.scalable) {
			text.rectTransform.DOScale(textParameter.targetScale, textParameter.scalingDuration).SetEase(textParameter.scalingEaseType);
		}

		// フェードイン
		if (textParameter.fadable) {
			text.DOFade(0, 0);
			text.DOFade(1, textParameter.inDuration);

			// 待機
			await UniTask.Delay(TimeSpan.FromSeconds(textParameter.normalDuration), cancellationToken: token);

			// フェードアウト
			text.DOFade(0, textParameter.outDuration).OnComplete(() => {
				completeAction?.Invoke();
			});
		}

		else {
			completeAction?.Invoke();
		}
	}

	/// <summary>
	/// テキストの表示(色の指定可能)
	/// </summary>
	public async void DispText(TextMeshProUGUI text, Color color, string message = null,  Action completeAction = null)
	{
		// 文字変更
		text.text = message;

		if (textParameter.colorable) {
			text.color = color;
		}

		// 移動、スケーリング
		if (textParameter.movable) {
			text.rectTransform.DOLocalMove(textParameter.startPosition, 0);       // 初期座標に移動
			text.rectTransform.DOLocalMove(textParameter.targetPosition, textParameter.movingDuration).SetEase(textParameter.movingEaseType);
		}

		if (textParameter.scalable) {
			text.rectTransform.DOScale(textParameter.targetScale, textParameter.scalingDuration).SetEase(textParameter.scalingEaseType);
		}

		// フェードイン
		if (textParameter.fadable) {
			text.DOFade(0, 0);
			text.DOFade(1, textParameter.inDuration);

			// 待機
			await UniTask.Delay(TimeSpan.FromSeconds(textParameter.normalDuration), cancellationToken: token);

			// フェードアウト
			text.DOFade(0, textParameter.outDuration).OnComplete(() => {
				completeAction?.Invoke();
			});
		}

		else {
			completeAction?.Invoke();
		}
	}
}
