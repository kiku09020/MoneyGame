using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

namespace Game.Goods.Mover {
    public class GoodsMover : MonoBehaviour {

        [SerializeField] MoveUnit toMiddle;
        [SerializeField] MoveUnit toBascket;

        public MoveUnit ToMiddle => toMiddle;
        public MoveUnit ToBascket => toBascket;

        //--------------------------------------------------

        [Serializable]
        public class MoveUnit
        {
            [SerializeField] RectTransform targetPoint;
            [SerializeField] GoodsParams moveParam;
            [SerializeField] UnityEvent completedAction;

            public void MoveToTargetPoint(Goods goods)
            {
				var seauence = DOTween.Sequence();

				seauence.Append(MoveBase(goods, targetPoint, moveParam))
					.Join(Scaling(goods, moveParam));
			}

			// �ړ���ꃁ�\�b�h
			Tween MoveBase(Goods target, Transform targetPoint, GoodsParams moveParams)
			{
				if (moveParams.doJump) {
					var tween = target.RectTransform.DOJumpAnchorPos(targetPoint.localPosition, moveParams.jumpPower, 1, moveParams.duration);
					return Sequences(tween);
				}

				else {
					var tween = target.RectTransform.DOAnchorPos(targetPoint.localPosition, moveParams.duration);
					return Sequences(tween);
				}

				// �C�[�W���O�Ƃ����낢��
				Tween Sequences(Tween tween)
				{
					return tween.SetEase(moveParams.movingEaseType)         // �C�[�W���O

						// �������ɃQ�[���I�u�W�F�N�g���폜
						.OnComplete(() => {
							if (moveParams.isDestroyed) {
								Destroy(target.gameObject);
							}

							// ���̑��̊������̏���
							completedAction?.Invoke();
						});
				}
			}

			// �X�P�[�����O
			Tween Scaling(Goods target, GoodsParams moveParams)
			{
				if (moveParams.doScale) {
					return target.transform.DOScale(moveParams.targetScale, moveParams.duration)
						.SetEase(moveParams.scalingEaseType);
				}

				return target.transform.DOScale(Vector2.one, 0);
			}
		}

		//--------------------------------------------------

		/// <summary>
		/// �����܂ňړ�
		/// </summary>
		public void MoveToGoodsPoint(Goods targetGoods)
        {
            toMiddle.MoveToTargetPoint(targetGoods);
        }

        /// <summary>
        /// �����������܂ňړ�
        /// </summary>
        public void MoveToBacketPoint(Goods targetGoods)
        {
            ToBascket.MoveToTargetPoint(targetGoods);
        }


    }
}