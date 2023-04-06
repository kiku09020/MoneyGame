using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test {
    public class StageHitChecker : HitCheckerCollisionBase {
        [SerializeField] Plaeyer player;

        //--------------------------------------------------

        protected override void HitEnterAction()
        {
            player.Rend.color = Color.white;
            print("enter");
        }

        protected override void HitExitAction()
        {
            player.Rend.color = Color.yellow;
            print("exit");
        }
    }
}