using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class HitTriggerBase : HitCheckerBase
{

    //--------------------------------------------------
    // BaseCheck(Trigger)
    void HitTriggerCheck(Collider2D collision, Action action)
    {
        if (collision.gameObject.tag == targetTag) {
            action?.Invoke();
        }
    }

    // TriggerEnter
    public void HitTriggerEnter(Collider2D collision)
    {
        HitTriggerCheck(collision, () => {
            IsHit = true;
            HitEnterAction();
        });
    }

    // TriggerStay
    public void HitTriggerStay(Collider2D collision)
    {
        HitTriggerCheck(collision, () => {
            IsHit = true;
            HitStayAction();
        });
    }

    // TriggerExit
    public void HitTriggerExit(Collider2D collision)
    {
        HitTriggerCheck(collision, () => {
            IsHit = false;
            HitExitAction();
        });
    }
}
