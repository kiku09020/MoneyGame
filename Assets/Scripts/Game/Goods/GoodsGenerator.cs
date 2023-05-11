using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Goods {
    using Mover;

    public class GoodsGenerator : MonoBehaviour {

        [Header("Prefab")]
        [SerializeField] Goods goodsPrefab;

        [Header("Components")]
        [SerializeField] GoodsMover mover;

        int generatedCount;

		//--------------------------------------------------

        public Goods CurrentGoods { get; private set; }

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
            CurrentGoods = Instantiate(goodsPrefab, startPos, Quaternion.identity, transform.parent);      // 生成

            CurrentGoods.name = goodsPrefab.name + $"({generatedCount})";       // 生成されたオブジェクトの名前を変更
                                                                                
            generatedCount++;                                                   // 生成数追加

            mover.MoveToGoodsPoint(CurrentGoods);                               // 中央に移動
        }
    }
}