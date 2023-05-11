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
		/// ���i�𐶐�
		/// </summary>
		public void GenerateGoods()
        {
            var startPos = transform.position;
            CurrentGoods = Instantiate(goodsPrefab, startPos, Quaternion.identity, transform.parent);      // ����

            CurrentGoods.name = goodsPrefab.name + $"({generatedCount})";       // �������ꂽ�I�u�W�F�N�g�̖��O��ύX
                                                                                
            generatedCount++;                                                   // �������ǉ�

            mover.MoveToGoodsPoint(CurrentGoods);                               // �����Ɉړ�
        }
    }
}