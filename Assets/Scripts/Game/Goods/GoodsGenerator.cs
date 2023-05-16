using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Goods {
	using Game.Money.MoneyManager;
	using Mover;

    public class GoodsGenerator : MonoBehaviour {

        [SerializeField] GoodsDataManager dataManager;

        [Header("Prefab")]
        [SerializeField] Goods goodsPrefab;

        [Header("Components")]
        [SerializeField] GoodsMover mover;

		//--------------------------------------------------

        /// <summary>
        /// ���i
        /// </summary>
        public Goods TargetGoods { get; private set; }

		private void Awake()
		{
			GenerateGoods();
		}

		/// <summary>
		/// ���i�𐶐�
		/// </summary>
		public void GenerateGoods()
        {
            var startPos = transform.position;

            // ���i����A���i���擾
            var price = TargetPriceSetter.TargetPrice;
            var goods = dataManager.GetGoods(price);

            TargetGoods = Instantiate(goods, startPos, Quaternion.identity, transform.parent);      // ����

            mover.MoveToGoodsPoint(TargetGoods);                               // �����Ɉړ�
        }
    }
}