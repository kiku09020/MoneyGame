using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Cysharp.Threading.Tasks;

public class SceneControllerAsync : SceneControllerBase<SceneControllerAsync>
{
    public async void LoadNowScene(Action<AsyncOperation> loadingAction = null)
    {
        await LoadIEnumerator(loadingAction, NowScene.SceneIndex);
    }

    public async void LoadNextScene(Action<AsyncOperation> loadingAction = null)
    {
        if (CheckNextSceneIndex()) {
            await LoadIEnumerator(loadingAction, NowScene.SceneIndex + 1);
        }
    }

    public async void LoadPrevScene(Action<AsyncOperation> loadingAction = null)
    {
        if (CheckPrevSceneIndex()) {
            await LoadIEnumerator(loadingAction, NowScene.SceneIndex - 1);
        }
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
