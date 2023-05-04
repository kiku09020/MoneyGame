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
	[SerializeField] string message;

	// フェード
	[HideInInspector] public bool fadable;
	[HideInInspector] public float inDuration		= .25f;
	[HideInInspector] public float outDuration		= .25f;
	[HideInInspector] public float normalDuration	= .5f;

	// 移動
	[HideInInspector] public bool movable;
	[HideInInspector] public float movingDuration	= .5f;
	[HideInInspector] public Vector2 targetPosition;
	[HideInInspector] public Ease movingEaseType;

	// サイズ
	[HideInInspector] public bool scalable;
	[HideInInspector] public float scalingDuration	= .5f;
	[HideInInspector] public Vector2 targetScale = Vector2.one;
	[HideInInspector] public Ease scalingEaseType;


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
	/// テキストの表示
	/// </summary>
	public async void DispText(TextMeshProUGUI text, CancellationToken token, Action completeAction = null)
	{
		// 移動、スケーリング
		text.rectTransform.DOLocalMove(targetPosition, movingDuration).SetEase(movingEaseType);
		text.rectTransform.DOScale(targetScale, scalingDuration).SetEase(scalingEaseType);

		// 文字変更
		text.text = message;

		// フェードイン
		text.DOFade(0, 0);
		text.DOFade(1, inDuration);

		// 待機
		await UniTask.Delay(TimeSpan.FromSeconds(normalDuration), cancellationToken: token);

		// フェードアウト
		text.DOFade(0, outDuration).OnComplete(() => {
			completeAction?.Invoke();
		});
	}

	/// <summary>
	/// テキストの表示(メッセージ指定可能)
	/// </summary>
	public async void DispText(TextMeshProUGUI text,string message, CancellationToken token, Action completeAction = null)
	{
		// 移動、スケーリング
		text.rectTransform.DOLocalMove(targetPosition, movingDuration).SetEase(movingEaseType);
		text.rectTransform.DOScale(targetScale, scalingDuration).SetEase(scalingEaseType);

		// 文字変更
		text.text = message;

		// フェードイン
		text.DOFade(0, 0);
		text.DOFade(1, inDuration);

		// 待機
		await UniTask.Delay(TimeSpan.FromSeconds(normalDuration), cancellationToken: token);

		// フェードアウト
		text.DOFade(0, outDuration).OnComplete(() => {
			completeAction?.Invoke();
		});
	}
}
