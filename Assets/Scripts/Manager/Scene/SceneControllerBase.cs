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
        NowScene.Setup();       // 現在の状態のセットアップ

        // イベント追加
        SceneManager.sceneLoaded += SceneLoaded;
        sceneCount = SceneManager.sceneCountInBuildSettings;
    }

    // 読み込み完了時の処理
    static void SceneLoaded(Scene scene,LoadSceneMode sceneMode)
    {
        NowScene.Setup();

        /* ここに処理を追加 */
        BGM.Instance.Stop();
    }

    /// <summary>
    /// 指定されたindexのシーンが存在するかチェック
    /// </summary>
    protected static bool CheckSceneIndex(int index)
    {
		if (index > 0 && index < sceneCount) {
            return true;
        }

        return false;
	}

    /// <summary>
    /// 次のシーンの読み込みチェック
    /// </summary>
    protected static bool CheckNextSceneIndex()
    {
        var index = NowScene.SceneIndex + 1;

        if (index < sceneCount) {
            return true;
        }

        else {
            Debug.LogWarning("次のシーンは存在しません。");
            return false;
        }
    }

    /// <summary>
    /// 前のシーンの読み込みチェック
    /// </summary>
    protected static bool CheckPrevSceneIndex()
    {
        var index = NowScene.SceneIndex - 1;

        if (0 <= index) {
            return true;
        }

        else {
            Debug.LogWarning("前のシーンは存在しません。");
            return false;
        }
    }
}
