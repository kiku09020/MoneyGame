using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Rendering;

public class LoadingController : MonoBehaviour
{
    [SerializeField] Slider loadingProgressBar;

    bool loading;

    //--------------------------------------------------

    void Awake()
    {
    }

	private void Update()
	{
        if (SplashScreen.isFinished && !loading) {
            loading = true;
            SceneControllerAsync.Instance.LoadNextScene(Loading);
        }
	}

	void Loading(AsyncOperation async)
    {
        loadingProgressBar.value = async.progress;
    }
}
