using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class SceneController : MonoBehaviour
{
    static int sceneCount;

    //-------------------------------------------

    private void Awake()
    {
        // シーン読み込み完了時のイベント追加
        SceneManager.sceneLoaded += SceneLoaded;

        SceneInfoSetup();
    }

    // シーン読み込み完了時に呼び出される
    void SceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        NowScene.Setup();
    }

    // シーン情報のセットアップ
    void SceneInfoSetup()
    {
        sceneCount = SceneManager.sceneCount;
    }

    //-------------------------------------------
    /// <summary>
    /// 現在のシーンを読み込む
    /// </summary>
    public static void LoadNowScene()
    {
        SceneManager.LoadScene(NowScene.SceneIndex);
    }

    /// <summary>
    /// 次のシーンを読み込む
    /// </summary>
    public static void LoadNextScene()
    {
        var index = NowScene.SceneIndex + 1;

        // 読み込み
        if (index < sceneCount) {
            SceneManager.LoadScene(index);
        }

        // 警告
        else {
            Debug.LogWarning("次のシーンは存在しません。");
        }
    }

    /// <summary>
    /// 前のシーンを読み込む
    /// </summary>
    public static void LoadPrevScene()
    {
        var index = NowScene.SceneIndex - 1;

        // 読み込み
        if (index > 0) {
            SceneManager.LoadScene(index);
        }

        // 警告
        else {
            Debug.LogWarning("前のシーンは存在しません。");
        }
    }

    //-------------------------------------------

    /// <summary>
    /// シーン番号指定で読み込む
    /// </summary>
    public static void LoadScene(int index)
    {
        // 読み込み
        if (index > 0 && index < sceneCount) {
            SceneManager.LoadScene(index);
        }

        // 警告
        else {
            Debug.LogWarning("指定されたシーン番号のシーンは存在しません。");
        }
    }

    /// <summary>
    /// シーン名指定で読み込む
    /// </summary>
    public static void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
