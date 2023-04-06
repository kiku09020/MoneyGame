using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheckTriggerManager : HitCheckManagerBase<HitTriggerBase>
{

    //--------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var hitChecker in hitCheckerList) {
            hitChecker.HitTriggerEnter(collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        foreach (var hitChecker in hitCheckerList) {
            hitChecker.HitTriggerStay(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (var hitChecker in hitCheckerList) {
            hitChecker.HitTriggerExit(collision);
        }
    }
}
