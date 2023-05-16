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
        /// 商品
        /// </summary>
        public Goods TargetGoods { get; private set; }

		private void Awake()
		{
			GenerateGoods();
		}

		/// <summary>
		/// 商品を生成
		/// </summary>
		public void GenerateGoods()
        {
            var startPos = transform.position;

            // 価格から、商品を取得
            var price = TargetPriceSetter.TargetPrice;
            var goods = dataManager.GetGoods(price);

            TargetGoods = Instantiate(goods, startPos, Quaternion.identity, transform.parent);      // 生成

            mover.MoveToGoodsPoint(TargetGoods);                               // 中央に移動
        }
    }
}