using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Goods.Mover {

    [CreateAssetMenu(fileName ="GoodsMoveParams",menuName ="ScriptableObject/GoodsMoveParams")]
    public class GoodsMoveParams : ScriptableObject {

        [Header("Move")]
        [Range(0,1)] public float moveDuration = 0.5f;
        public Ease moveEaseType;

        [Header("Jump")]
        public bool doJump;
        [Range(50, 500)] public float jumpPower;

        //--------------------------------------------------

    }
}