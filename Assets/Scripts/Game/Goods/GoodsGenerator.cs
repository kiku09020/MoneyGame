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

		//--------------------------------------------------

		private void Awake()
		{
			GenerateGoods();
		}

		/// <summary>
		/// ¤•i‚ğ¶¬
		/// </summary>
		public void GenerateGoods()
        {
            var startPos = transform.position;
            var obj = Instantiate(goodsPrefab, startPos, Quaternion.identity, transform.parent);      // ¶¬
                                                        
            mover.MoveToGoodsPoint(obj);                        // ’†‰›‚ÉˆÚ“®
        }
    }
}