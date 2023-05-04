using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using GameController;

public class ReadyTextController : TextController_Base
{
    [Header("Parameters")]
    [SerializeField] string startMessage = "Start!";
    [SerializeField, Range(0,1)] float waitDuration;            // Ready�e�L�X�g�\����̑ҋ@����

    [Header("Components")]
    [SerializeReference] GameStateMachine state;

    //--------------------------------------------------

    public async void StartingAction()
    {
        text.gameObject.SetActive(true);        // �\��

        var prevPos = text.rectTransform.anchoredPosition;
        var prevScale = text.rectTransform.localScale;

        DispText(text,token);
        await UniTask.Delay(TimeSpan.FromSeconds(waitDuration), cancellationToken: token);

        text.rectTransform.anchoredPosition = prevPos;      // ���Ƃɖ߂�
        text.rectTransform.localScale = prevScale;

        // �J��
        DispText(text, startMessage, token, () => {
            state.StateTransition<MainState>();
        });
    }
}
