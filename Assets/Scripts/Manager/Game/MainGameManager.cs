using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameController;

public class MainGameManager : MonoBehaviour
{
    [SerializeField] GameStateMachine state;

    /// <summary>
    /// 操作可能フラグ
    /// </summary>
    public static bool isOperable;

    /// <summary>
    /// ゲーム終了フラグ
    /// </summary>
    public static bool isGameEnd;

	//--------------------------------------------------

	private void Start()
    {
        isGameEnd = false;
        isOperable = false;

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
