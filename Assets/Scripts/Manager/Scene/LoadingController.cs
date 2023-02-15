using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingController : MonoBehaviour
{
    LoadingUIGroup loadingUI;

    //--------------------------------------------------
    private void Start()
    {
        loadingUI = UIManager.GetUIGroup<LoadingUIGroup>();
    }

    public void Loading()
    {
        UIManager.ShowUIGroup(loadingUI);
        SceneControllerAsync.Instance.LoadPrevScene(loadingUI.Loading);
    }
}
