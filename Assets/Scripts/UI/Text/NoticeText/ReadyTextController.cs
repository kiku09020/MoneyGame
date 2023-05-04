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
    [SerializeField, Range(0,1)] float waitDuration;            // Readyテキスト表示後の待機時間

    [Header("Components")]
    [SerializeReference] GameStateMachine state;

    //--------------------------------------------------

    public async void StartingAction()
    {
        text.gameObject.SetActive(true);        // 表示

        var prevPos = text.rectTransform.anchoredPosition;
        var prevScale = text.rectTransform.localScale;

        DispText(text,token);
        await UniTask.Delay(TimeSpan.FromSeconds(waitDuration), cancellationToken: token);

        text.rectTransform.anchoredPosition = prevPos;      // もとに戻す
        text.rectTransform.localScale = prevScale;

        // 遷移
        DispText(text, startMessage, token, () => {
            state.StateTransition<MainState>();
        });
    }
}
