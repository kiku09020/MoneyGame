using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameController;

public class MainGameManager : MonoBehaviour
{
    [SerializeField] GameStateMachine state;

    private void Start()
    {
        state.StateInit();
        BGM.Instance.Play(AudioNames.BGM_PALETTE, 0, 0.5f, 1);
    }

	void FixedUpdate()
    {
        state.StateUpdate();
    }

    /// <summary>
    /// ゲームをやり直す
    /// </summary>
    public void RestartGame()
    {
        SceneControllerAsync.Instance.LoadNowScene();
    }

    /// <summary>
    /// ゲームを終了して、タイトルに戻る
    /// </summary>
    public void ExitGame()
    {
        SceneControllerAsync.Instance.LoadPrevScene();
    }
}
