using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using GameController;

public class ReadyTextController : TextController_Base
{
    [Header("Parameters")]
    [SerializeField, Range(0,1)] float waitDuration;            // Ready�e�L�X�g�\����̑ҋ@����

    [Header("TextUnit")]
    [SerializeField] TextUnit readyText;
    [SerializeField] TextUnit startText;

    [Header("Components")]
    [SerializeReference] GameStateMachine state;

    //--------------------------------------------------

    public async void StartingAction()
    {
        text.gameObject.SetActive(true);        // �\��

        var prevPos = text.rectTransform.anchoredPosition;
        readyText.DispText(text,token);
        await UniTask.Delay(TimeSpan.FromSeconds(waitDuration), cancellationToken: token);

        text.rectTransform.anchoredPosition = prevPos;      // ���Ƃɖ߂�

        // �J��
        startText.DispText(text, token, () => {
            state.StateTransition<MainState>();
        });
    }
}
