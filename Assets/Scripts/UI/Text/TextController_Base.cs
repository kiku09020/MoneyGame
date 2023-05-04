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

	// �t�F�[�h
	[HideInInspector] public bool fadable;
	[HideInInspector] public float inDuration		= .25f;
	[HideInInspector] public float outDuration		= .25f;
	[HideInInspector] public float normalDuration	= .5f;

	// �ړ�
	[HideInInspector] public bool movable;
	[HideInInspector] public float movingDuration	= .5f;
	[HideInInspector] public Vector2 targetPosition;
	[HideInInspector] public Ease movingEaseType;

	// �T�C�Y
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

		// ��\��
		text.gameObject.SetActive(false);
	}

	/// <summary>
	/// �e�L�X�g�̕\��
	/// </summary>
	public async void DispText(TextMeshProUGUI text, CancellationToken token, Action completeAction = null)
	{
		// �ړ��A�X�P�[�����O
		text.rectTransform.DOLocalMove(targetPosition, movingDuration).SetEase(movingEaseType);
		text.rectTransform.DOScale(targetScale, scalingDuration).SetEase(scalingEaseType);

		// �����ύX
		text.text = message;

		// �t�F�[�h�C��
		text.DOFade(0, 0);
		text.DOFade(1, inDuration);

		// �ҋ@
		await UniTask.Delay(TimeSpan.FromSeconds(normalDuration), cancellationToken: token);

		// �t�F�[�h�A�E�g
		text.DOFade(0, outDuration).OnComplete(() => {
			completeAction?.Invoke();
		});
	}

	/// <summary>
	/// �e�L�X�g�̕\��(���b�Z�[�W�w��\)
	/// </summary>
	public async void DispText(TextMeshProUGUI text,string message, CancellationToken token, Action completeAction = null)
	{
		// �ړ��A�X�P�[�����O
		text.rectTransform.DOLocalMove(targetPosition, movingDuration).SetEase(movingEaseType);
		text.rectTransform.DOScale(targetScale, scalingDuration).SetEase(scalingEaseType);

		// �����ύX
		text.text = message;

		// �t�F�[�h�C��
		text.DOFade(0, 0);
		text.DOFade(1, inDuration);

		// �ҋ@
		await UniTask.Delay(TimeSpan.FromSeconds(normalDuration), cancellationToken: token);

		// �t�F�[�h�A�E�g
		text.DOFade(0, outDuration).OnComplete(() => {
			completeAction?.Invoke();
		});
	}
}
