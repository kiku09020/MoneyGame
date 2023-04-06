using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitCheckerBase : MonoBehaviour
{
    [HideInInspector] public string targetTag;
    [HideInInspector] public LayerMask targetLayerMask;
    [HideInInspector] public bool isEnableTag;
    [HideInInspector] public bool isEnableLayerMask;

    public bool IsHit { get; protected set; }

    //--------------------------------------------------


    /// <summary>
    /// 当たった時の処理
    /// </summary>
    protected abstract void HitEnterAction();

    /// <summary>
    /// 当たっている時の処理
    /// </summary>
    protected virtual void HitStayAction() { }

    /// <summary>
    /// 離れた時の処理
    /// </summary>
    protected abstract void HitExitAction();
}
