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

	//--------------------------------------------------

	protected CancellationToken token;

	[Serializable]
	protected class TextUnit {
		[Header("Durations")]
		[SerializeField, Range(0, 0.5f)] float inDuration;
		[SerializeField, Range(0, 0.5f)] float outDuration;
		[SerializeField, Range(0, 1.0f)] float textDuration;

		[Header("Moving")]
		[SerializeField] Vector2 targetPos;

		[Header("Message")]
		[SerializeField] string message;

		public async void DispText(TextMeshProUGUI text, CancellationToken token, Action action = null)
		{
			text.rectTransform.DOLocalMove(targetPos, inDuration);

			// 文字変更
			text.text = message;

			// フェードイン
			text.DOFade(0, 0);
			text.DOFade(1, inDuration);

			// 待機
			await UniTask.Delay(TimeSpan.FromSeconds(textDuration), cancellationToken: token);

			// フェードアウト
			text.DOFade(0, outDuration).OnComplete(() => {
				action?.Invoke();
			});
		}
	}

	//--------------------------------------------------

	void Awake()
	{
		token = this.GetCancellationTokenOnDestroy();

		// 非表示
		text.gameObject.SetActive(false);
	}
}
