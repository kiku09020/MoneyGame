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

		// ��\��
		text.gameObject.SetActive(false);
	}

	/// <summary>
	/// �e�L�X�g�̕\��(���b�Z�[�W�w��\)
	/// </summary>
	public async void DispText(TextMeshProUGUI text, string message = null, Action completeAction = null)
	{
		// �����ύX
		text.text = message;

		// �����F�ύX
		if (textParameter.colorable) {
			text.color = textParameter.targetColor;
		}

		// �ړ��A�X�P�[�����O
		if (textParameter.movable) {
			text.rectTransform.DOLocalMove(textParameter.startPosition, 0);		// �������W�Ɉړ�
			text.rectTransform.DOLocalMove(textParameter.targetPosition, textParameter.movingDuration).SetEase(textParameter.movingEaseType);
		}

		if (textParameter.scalable) {
			text.rectTransform.DOScale(textParameter.targetScale, textParameter.scalingDuration).SetEase(textParameter.scalingEaseType);
		}

		// �t�F�[�h�C��
		if (textParameter.fadable) {
			text.DOFade(0, 0);
			text.DOFade(1, textParameter.inDuration);

			// �ҋ@
			await UniTask.Delay(TimeSpan.FromSeconds(textParameter.normalDuration), cancellationToken: token);

			// �t�F�[�h�A�E�g
			text.DOFade(0, textParameter.outDuration).OnComplete(() => {
				completeAction?.Invoke();
			});
		}

		else {
			completeAction?.Invoke();
		}
	}

	/// <summary>
	/// �e�L�X�g�̕\��(�F�̎w��\)
	/// </summary>
	public async void DispText(TextMeshProUGUI text, Color color, string message = null,  Action completeAction = null)
	{
		// �����ύX
		text.text = message;

		if (textParameter.colorable) {
			text.color = color;
		}

		// �ړ��A�X�P�[�����O
		if (textParameter.movable) {
			text.rectTransform.DOLocalMove(textParameter.startPosition, 0);       // �������W�Ɉړ�
			text.rectTransform.DOLocalMove(textParameter.targetPosition, textParameter.movingDuration).SetEase(textParameter.movingEaseType);
		}

		if (textParameter.scalable) {
			text.rectTransform.DOScale(textParameter.targetScale, textParameter.scalingDuration).SetEase(textParameter.scalingEaseType);
		}

		// �t�F�[�h�C��
		if (textParameter.fadable) {
			text.DOFade(0, 0);
			text.DOFade(1, textParameter.inDuration);

			// �ҋ@
			await UniTask.Delay(TimeSpan.FromSeconds(textParameter.normalDuration), cancellationToken: token);

			// �t�F�[�h�A�E�g
			text.DOFade(0, textParameter.outDuration).OnComplete(() => {
				completeAction?.Invoke();
			});
		}

		else {
			completeAction?.Invoke();
		}
	}
}
