using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultButtonsController : MonoBehaviour
{

    //--------------------------------------------------

    // ���g���C�{�^��
    public void OnRetry()
    {
        SceneControllerAsync.Instance.LoadNowScene();
    }

    // �I���{�^��
    public void OnExit()
    {
        SceneControllerAsync.Instance.LoadPrevScene();
    }

    // ���L�{�^��
    public void OnShare()
    {

    }

}
