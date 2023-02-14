using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class NowScene {
    /// <summary>
    /// 現在のシーン情報のセットアップ
    /// </summary>
    public static void Setup()
    {
        Scene = SceneManager.GetActiveScene();
        LogController.Log($"{SceneName} was setuped.",LogTag.Scene);
    }

    /// <summary>
    /// 現在のシーン
    /// </summary>
    public static Scene Scene { get; private set; }

    /// <summary>
    /// シーン番号
    /// </summary>
    public static int SceneIndex => Scene.buildIndex;

    /// <summary>
    /// シーン名
    /// </summary>
    public static string SceneName => Scene.name;

    /// <summary>
    /// シーンが有効か
    /// </summary>
    public static bool SceneIsValid => Scene.IsValid();
}
