using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{

    //--------------------------------------------------

    void Awake()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadGameScene()
    {
        SceneControllerAsync.Instance.LoadNextScene();
    }
}
