using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultButtonsController : MonoBehaviour
{

    //--------------------------------------------------

    // リトライボタン
    public void OnRetry()
    {
        SceneControllerAsync.Instance.LoadNowScene();
    }

    // 終了ボタン
    public void OnExit()
    {
        SceneControllerAsync.Instance.LoadPrevScene();
    }

    // 共有ボタン
    public void OnShare()
    {

    }

}
