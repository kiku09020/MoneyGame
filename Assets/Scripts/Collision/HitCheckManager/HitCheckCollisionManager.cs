using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
    public class HitCheckCollisionManager : HitCheckManagerBase<HitCheckerCollisionBase> {

        //--------------------------------------------------

        private void OnCollisionEnter2D(Collision2D collision)
        {
            foreach (var hitChecker in hitCheckerList) {
                hitChecker.HitEnter(collision);
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            foreach(var hitChecker in hitCheckerList) {
                hitChecker.HitStay(collision);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            foreach(var hitChecker in hitCheckerList) {
                hitChecker.HitExit(collision);
            }
        }

        //--------------------------------------------------


    }
}