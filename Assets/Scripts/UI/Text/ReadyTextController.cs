using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using GameController;

public class ReadyTextController : TextController_Base
{
    [Header("Parameters")]
    [SerializeField, Range(0,1)] float waitDuration;            // Readyテキスト表示後の待機時間

    [Header("TextUnit")]
    [SerializeField] TextUnit readyText;
    [SerializeField] TextUnit startText;

    [Header("Components")]
    [SerializeReference] GameStateMachine state;

    //--------------------------------------------------

    public async void StartingAction()
    {
        text.gameObject.SetActive(true);        // 表示

        var prevPos = text.rectTransform.anchoredPosition;
        readyText.DispText(text,token);
        await UniTask.Delay(TimeSpan.FromSeconds(waitDuration), cancellationToken: token);

        text.rectTransform.anchoredPosition = prevPos;      // もとに戻す

        // 遷移
        startText.DispText(text, token, () => {
            state.StateTransition<MainState>();
        });
    }
}
