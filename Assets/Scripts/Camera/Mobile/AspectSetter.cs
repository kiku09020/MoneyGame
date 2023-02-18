using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Camera))]
public class AspectSetter : MonoBehaviour
{
    Camera _camera;

    [SerializeField] Vector2 targetResolution;      // �ڕW�̉𑜓x
    [SerializeField] bool isUpdate;                 // ���t���[����ʂ����낦�邩

    private void Awake()
    {
        _camera = GetComponent<Camera>();
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
        var scrnAspect = (float)Screen.width / (float)Screen.height;        // ���݂̃A�X�y�N�g��
        var targAspect = targetResolution.x / targetResolution.y;           // �ڕW�̃A�X�y�N�g��

        var rate = targAspect / scrnAspect;     // ���݂ƖڕW�Ƃ̔䗦
        var rect = new Rect(0, 0, 1, 1);

        // �{�����������ꍇ�A�������낦��
        if (rate < 1) {
            rect.width = rate;
            rect.x = 0.5f - rect.width * 0.5f;
        }

        // �c�����낦��
        else {
            rect.height = 1 / rate;
            rect.y = 0.5f - rect.height * 0.5f;
        }

        // ���f
        _camera.rect = rect;
    }
}
