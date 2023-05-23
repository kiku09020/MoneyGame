using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Game.Goods {
	[CreateAssetMenu(fileName = "GoodsDataList", menuName = "ScriptableObject/GoodsDataList")]
	public class GoodsDataManager : ScriptableObject {

		[Header("GoodsData")]
		[SerializeField,Tooltip("���i�f�[�^�N���X�̃��X�g")] List<GoodsData> goodsDataList;

		[Header("Other")]
		[SerializeField,Tooltip("�͈͊O�̒l�i���w�肳�ꂽ�ꍇ�ɑI�o����鏤�i")] Goods defaultGoods;

		//--------------------------------------------------
		/// <summary>
		/// ���i���X�g�ƃ��X�g�̓K�p�͈͂��i�[�����N���X
		/// </summary>
		[System.Serializable]
		class GoodsData
		{
			[SerializeField] string name;

			[Header("Parameters")]
			// �ŏ��l�A�ő�l
			[SerializeField] int minPrice;
			[SerializeField] int maxPrice;    

			[Header("List")]
			[SerializeField] List<Goods> goodsList;		// ���i���X�g

			/// <summary>
			/// �w�肳�ꂽ�l�i���ŏ��l�A�ő�l�͈͓̔����ǂ������擾����
			/// </summary>
			/// <param name="price">�l�i</param>
			/// <returns>�͈͓����ǂ���</returns>
			public bool CheckIsInRegion(int price)
			{
				if (minPrice <= price && price < maxPrice) {
					return true;
				}

				return false;
			}

			/// <summary>
			/// ���X�g���烉���_���ŗv�f���擾����
			/// </summary>
			public Goods GetGoods()
			{
				int randomIndex = Random.Range(0, goodsList.Count);

				return goodsList[randomIndex];
			}
		}

		//--------------------------------------------------

		/// <summary>
		/// �l�i�ɉ��������i���擾����
		/// </summary>
		/// <param name="price">�l�i</param>
		public Goods GetGoods(int price)
		{
			foreach(var goodsData in goodsDataList) {
				if(goodsData.CheckIsInRegion(price)) {
					return goodsData.GetGoods();
				}
			}

			// �w�肳�ꂽ�l�i���A�ǂ̃��X�g�ɂ��܂܂�Ȃ��ꍇ�A�f�t�H���g�̏��i��Ԃ�
			return defaultGoods;
		}
	}
}