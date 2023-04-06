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
    /// “–‚½‚Á‚½‚Ìˆ—
    /// </summary>
    protected abstract void HitEnterAction();

    /// <summary>
    /// “–‚½‚Á‚Ä‚¢‚é‚Ìˆ—
    /// </summary>
    protected virtual void HitStayAction() { }

    /// <summary>
    /// —£‚ê‚½‚Ìˆ—
    /// </summary>
    protected abstract void HitExitAction();
}
