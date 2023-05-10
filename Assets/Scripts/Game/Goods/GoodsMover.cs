using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Goods.Mover {
    public class GoodsMover : MonoBehaviour {

        [Header("Points")]
        [SerializeField] RectTransform goodsPoint;          // ����
        [SerializeField] RectTransform backetPoint;         // ����������

        [Header("Mover")]
        [SerializeField] GoodsMoveParams moveParam_GoodsPoint;
        [SerializeField] GoodsMoveParams moveParam_BacketPoint;

        //--------------------------------------------------

        /// <summary>
        /// �����܂ňړ�
        /// </summary>
        public void MoveToGoodsPoint(Goods targetGoods)
        {
            MoveBase(targetGoods, goodsPoint, moveParam_GoodsPoint);
        }

        /// <summary>
        /// �����������܂ňړ�
        /// </summary>
        public void MoveToBacketPoint(Goods targetGoods)
        {
            MoveBase(targetGoods, backetPoint, moveParam_BacketPoint);
        }

        // ��ꃁ�\�b�h
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