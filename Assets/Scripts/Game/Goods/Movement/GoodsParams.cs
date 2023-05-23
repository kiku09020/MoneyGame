using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Goods.Mover {

    [CreateAssetMenu(fileName ="GoodsMoveParams",menuName ="ScriptableObject/GoodsMoveParams")]
    public class GoodsParams : ScriptableObject {

        [Header("Base")]
        [Range(0,1)] public float duration = 0.5f;

        [Header("Moving")]
        public Ease movingEaseType;

        [Header("Juming")]
        public bool doJump;
        [Range(50, 500)] public float jumpPower;

        [Header("Scaling")]
        public bool doScale;
        public Vector2 targetScale;
        public Ease scalingEaseType;

        [Header("Completed")]
        public bool isDestroyed;

        //--------------------------------------------------

    }
}