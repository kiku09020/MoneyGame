using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System.Threading;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

public class ReadyTextController : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField, Range(0,1)] float waitDuration;            // Ready�e�L�X�g�\����̑ҋ@����

    [Header("TextUnit")]
    [SerializeField] TextUnit readyText;
    [SerializeField] TextUnit startText;

    [Header("Components")]
    [SerializeField] TextMeshProUGUI text;

    //--------------------------------------------------
    CancellationToken token;

    [Serializable]
    class TextUnit
    {
        [Header("Durations")]
        [SerializeField, Range(0, 0.5f)] float inDuration;
        [SerializeField, Range(0, 0.5f)] float outDuration;
        [SerializeField, Range(0, 1.0f)] float textDuration;

        [Header("Moving")]
        [SerializeField] Vector2 targetPos;

        [Header("Message")]
        [SerializeField] string message;

        public async void DispText(TextMeshProUGUI text,CancellationToken token)
        {
            text.rectTransform.DOLocalMove(targetPos, inDuration);

			// �����ύX
			text.text = message;        

            // �t�F�[�h�C��
            text.DOFade(0, 0);
            text.DOFade(1, inDuration);

            // �ҋ@
            await UniTask.Delay(TimeSpan.FromSeconds(textDuration), cancellationToken: token);

            // �t�F�[�h�A�E�g
            text.DOFade(0, outDuration);
        }
    }

	//--------------------------------------------------

	void Awake()
    {
        token=this.GetCancellationTokenOnDestroy();

        // ��\��
        text.gameObject.SetActive(false);
    }

    public async void StartingAction()
    {
        text.gameObject.SetActive(true);        // �\��

        var prevPos = text.rectTransform.anchoredPosition;
        readyText.DispText(text,token);
        await UniTask.Delay(TimeSpan.FromSeconds(waitDuration), cancellationToken: token);

        text.rectTransform.anchoredPosition = prevPos;      // ���Ƃɖ߂�
        startText.DispText(text,token);
    }
}
