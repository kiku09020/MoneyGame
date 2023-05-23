using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Game.Goods {
	[CreateAssetMenu(fileName = "GoodsDataList", menuName = "ScriptableObject/GoodsDataList")]
	public class GoodsDataManager : ScriptableObject {

		[Header("GoodsData")]
		[SerializeField,Tooltip("商品データクラスのリスト")] List<GoodsData> goodsDataList;

		[Header("Other")]
		[SerializeField,Tooltip("範囲外の値段が指定された場合に選出される商品")] Goods defaultGoods;

		//--------------------------------------------------
		/// <summary>
		/// 商品リストとリストの適用範囲を格納したクラス
		/// </summary>
		[System.Serializable]
		class GoodsData
		{
			[SerializeField] string name;

			[Header("Parameters")]
			// 最小値、最大値
			[SerializeField] int minPrice;
			[SerializeField] int maxPrice;    

			[Header("List")]
			[SerializeField] List<Goods> goodsList;		// 商品リスト

			/// <summary>
			/// 指定された値段が最小値、最大値の範囲内かどうかを取得する
			/// </summary>
			/// <param name="price">値段</param>
			/// <returns>範囲内かどうか</returns>
			public bool CheckIsInRegion(int price)
			{
				if (minPrice <= price && price < maxPrice) {
					return true;
				}

				return false;
			}

			/// <summary>
			/// リストからランダムで要素を取得する
			/// </summary>
			public Goods GetGoods()
			{
				int randomIndex = Random.Range(0, goodsList.Count);

				return goodsList[randomIndex];
			}
		}

		//--------------------------------------------------

		/// <summary>
		/// 値段に応じた商品を取得する
		/// </summary>
		/// <param name="price">値段</param>
		public Goods GetGoods(int price)
		{
			foreach(var goodsData in goodsDataList) {
				if(goodsData.CheckIsInRegion(price)) {
					return goodsData.GetGoods();
				}
			}

			// 指定された値段が、どのリストにも含まれない場合、デフォルトの商品を返す
			return defaultGoods;
		}
	}
}