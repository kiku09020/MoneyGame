using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test {
    public class DamageHitChecker : HitCheckerCollisionBase {
        [SerializeField] Plaeyer plaeyer;

        //--------------------------------------------------

        protected override void HitEnterAction()
        {
            plaeyer.Rend.color = Color.black;
        }

        protected override void HitExitAction()
        {
            plaeyer.Rend.color = Color.red;
        }
    }
}