using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Goods.Mover {
    public class GoodsMover : MonoBehaviour {

        [Header("Points")]
        [SerializeField] RectTransform goodsPoint;          // íÜâõ
        [SerializeField] RectTransform backetPoint;         // îÉÇ¢ï®Ç©Ç≤

        [Header("Mover")]
        [SerializeField] GoodsMoveParams moveParam_GoodsPoint;
        [SerializeField] GoodsMoveParams moveParam_BacketPoint;

        //--------------------------------------------------

        /// <summary>
        /// íÜâõÇ‹Ç≈à⁄ìÆ
        /// </summary>
        public void MoveToGoodsPoint(Goods targetGoods)
        {
            MoveBase(targetGoods, goodsPoint, moveParam_GoodsPoint);
        }

        /// <summary>
        /// îÉÇ¢ï®Ç©Ç≤Ç‹Ç≈à⁄ìÆ
        /// </summary>
        public void MoveToBacketPoint(Goods targetGoods)
        {
            MoveBase(targetGoods, backetPoint, moveParam_BacketPoint);
        }

        // äÓíÍÉÅÉ\ÉbÉh
        void MoveBase(Goods target,RectTransform targetPoint,GoodsMoveParams moveParams)
        {
            if(moveParams.doJump) {
                target.RectTransform.DOJumpAnchorPos(targetPoint.position, moveParams.jumpPower, 1, moveParams.moveDuration)
                    .SetEase(moveParams.moveEaseType);

			}

            else {
                target.RectTransform.DOAnchorPos(targetPoint.position, moveParams.moveDuration).SetEase(moveParams.moveEaseType);
            }
        }
    }
}