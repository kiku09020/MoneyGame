using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIGroupBase : MonoBehaviour
{
    /// <summary>
    /// UI�̏�����
    /// </summary>
    public virtual void Initialize() { }

    /// <summary>
    /// UI���\���ɂ���
    /// </summary>
    public virtual void Hide() => gameObject.SetActive(false);

    /// <summary>
    /// UI��\������
    /// </summary>
    public virtual void Show() => gameObject.SetActive(true);
}
