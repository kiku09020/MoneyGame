using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneControllerAsync : SceneControllerBase<SceneControllerAsync>
{
    public void LoadNowScene(Action<AsyncOperation> loadingAction = null)
    {
        StartCoroutine(LoadIEnumerator(loadingAction, NowScene.SceneIndex));
    }

    public void LoadNextScene(Action<AsyncOperation> loadingAction = null)
    {
        NextSceneLoadCheck(() =>
         StartCoroutine(LoadIEnumerator(loadingAction, NowScene.SceneIndex + 1)));
    }

    public void LoadPrevScene(Action<AsyncOperation> loadingAction = null)
    {
        PrevSceneLoadCheck(() =>
        StartCoroutine(LoadIEnumerator(loadingAction, NowScene.SceneIndex - 1)));
    }

    // コルーチン
    static IEnumerator LoadIEnumerator(Action<AsyncOperation> loadingAction, int sceneIndex)
    {
        var async = SceneManager.LoadSceneAsync(sceneIndex);

        while (!async.isDone) {

            // ロード処理
            if (loadingAction != null) {
                loadingAction(async);
            }
            yield return null;
        }
    }
}
