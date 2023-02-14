using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public abstract class SceneControllerBase<T> : Singleton<T> where T:SceneControllerBase<T>
{
    protected static int sceneCount;

    protected override void Awake()
    {
        // イベント追加
        SceneManager.sceneLoaded += SceneLoaded;
        sceneCount = SceneManager.sceneCountInBuildSettings;
    }

    // 読み込み完了時の処理
    static void SceneLoaded(Scene scene,LoadSceneMode sceneMode)
    {
        NowScene.Setup();

        /* ここに処理を追加 */
        
    }

    /// <summary>
    /// 次のシーンの読み込みチェック
    /// </summary>
    /// <param name="loadAction">ロード処理</param>
    protected static void NextSceneLoadCheck(Action loadAction)
    {
        var index = NowScene.SceneIndex + 1;

        if (index < sceneCount) {
            loadAction();
        }

        else {
            Debug.LogWarning("次のシーンは存在しません。");
        }
    }

    /// <summary>
    /// 前のシーンの読み込みチェック
    /// </summary>
    /// <param name="loadAction">ロード処理</param>
    protected static void PrevSceneLoadCheck(Action loadAction)
    {
        var index = NowScene.SceneIndex - 1;

        if (0 <= index) {
            loadAction();
        }

        else {
            Debug.LogWarning("前のシーンは存在しません。");
        }
    }
}
