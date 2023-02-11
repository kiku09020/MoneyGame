using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class AspectSetter : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] Camera camera;

    [Header("Parameters")]
    [SerializeField] Vector2 targetAspectVector;
    [SerializeField] bool isUpdate;


    private void Awake()
    {
        SetAspect();   
    }

    private void Update()
    {
        if (isUpdate) {
            SetAspect();
        }
    }

    void SetAspect()
    {
        var scrnAspect = (float)Screen.width / (float)Screen.height;
        var targAspect = targetAspectVector.x / targetAspectVector.y;

        var rate = targAspect / scrnAspect;
        var rect = new Rect(0, 0, 1, 1);

        // î{ó¶Ç™è¨Ç≥Ç¢èÍçáÅAâ°ÇÇªÇÎÇ¶ÇÈ
        if (rate < 1) {
            rect.width = rate;
            rect.x = 0.5f - rect.width * 0.5f;
        }

        // ècÇÇªÇÎÇ¶ÇÈ
        else {
            rect.height = 1 / rate;
            rect.y = 0.5f - rect.height * 0.5f;
        }

        camera.rect = rect;
    }
}
