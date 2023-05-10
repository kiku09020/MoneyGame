using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Goods.Mover {
    public class GoodsMover : MonoBehaviour {

        [Header("Points")]
        [SerializeField] RectTransform goodsPoint;          // 中央
        [SerializeField] RectTransform backetPoint;         // 買い物かご

        [Header("Mover")]
        [SerializeField] GoodsMoveParams moveParam_GoodsPoint;
        [SerializeField] GoodsMoveParams moveParam_BacketPoint;

        //--------------------------------------------------

        /// <summary>
        /// 中央まで移動
        /// </summary>
        public void MoveToGoodsPoint(Goods targetGoods)
        {
            MoveBase(targetGoods, goodsPoint, moveParam_GoodsPoint);
        }

        /// <summary>
        /// 買い物かごまで移動
        /// </summary>
        public void MoveToBacketPoint(Goods targetGoods)
        {
            MoveBase(targetGoods, backetPoint, moveParam_BacketPoint);
        }

        // 基底メソッド
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