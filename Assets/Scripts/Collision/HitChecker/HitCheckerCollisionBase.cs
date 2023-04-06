using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class HitCheckerCollisionBase : HitCheckerBase
{

    //--------------------------------------------------

    // BaseCheck(Collision)
    void HitCheck(Collision2D collision, Action action)
    {
        if (enabled) {
            if (isEnableLayerMask && targetLayerMask.value != 0) {
                if (((1 << collision.gameObject.layer) & targetLayerMask) != 0) {

                    // ���C���[���^�O
                    if (isEnableTag) {
                        if (collision.gameObject.tag == targetTag) {
                            action?.Invoke();
                        }
                    }

                    // ���C���[�̂ݔ���
                    else {
                        action?.Invoke();
                    }
                }
            }

            // �^�O�̂ݔ���
            else if (isEnableTag && collision.gameObject.tag == targetTag) {
                action?.Invoke();
            }
        }
    }

    // CollisionEnter
    public void HitEnter(Collision2D collision)
    {
        HitCheck(collision, () => {
            IsHit = true;
            HitEnterAction();
        });
    }

    // CollisionStay
    public void HitStay(Collision2D collision)
    {
        HitCheck(collision, () => {
            IsHit = true;
            HitStayAction();
        });
    }

    // CollisionExit
    public void HitExit(Collision2D collision)
    {
        HitCheck(collision, () => {
            IsHit = false;
            HitExitAction();
        });
    }
}
