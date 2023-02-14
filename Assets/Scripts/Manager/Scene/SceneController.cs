using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class SceneController : SceneControllerBase<SceneController>
{
    //-------------------------------------------
    /// <summary>
    /// 現在のシーンを読み込む
    /// </summary>
    public void LoadNowScene()
    {
        SceneManager.LoadScene(NowScene.SceneIndex);
    }

    /// <summary>
    /// 次のシーンを読み込む
    /// </summary>
    public void LoadNextScene()
    {
        NextSceneLoadCheck(() => SceneManager.LoadScene(NowScene.SceneIndex + 1));
    }

    /// <summary>
    /// 前のシーンを読み込む
    /// </summary>
    public void LoadPrevScene()
    {
        PrevSceneLoadCheck(() => SceneManager.LoadScene(NowScene.SceneIndex - 1));
    }

    //-------------------------------------------

    /// <summary>
    /// シーン番号指定で読み込む
    /// </summary>
    public void LoadScene(int index)
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
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
