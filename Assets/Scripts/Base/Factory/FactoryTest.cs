using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* !Example Classes! */

namespace Example {
	class ProductTest : ProductBase {
		public override void Initialize()
		{

		}
	}

	class FactoryTest : FactoryWithList {
		[SerializeField] ProductTest product;

		public override ProductBase GetProduct(Vector3 pos, Quaternion rot, Transform parent)
		{
			var instance = Instantiate(product.gameObject, pos, rot, parent);       // 生成
			var generatedProduct = instance.GetComponent<ProductTest>();            // コンポーネント取得

			generatedProduct.Initialize();              // 初期化
			AddToGeneratedList(generatedProduct);       // リストに追加

			return generatedProduct;
		}
	}

	class FactoryDictTest : FactoryWithDictionary {
		[SerializeField] ProductTest product;

		public override ProductBase GetProduct(Vector3 pos, Quaternion rot, Transform parent)
		{
			var instance = Instantiate(product.gameObject, pos, rot, parent);
			var generatedProduct = instance.GetComponent<ProductTest>();

			generatedProduct.Initialize();
			AddToGeneratedDict(generatedProduct, instance.name);

			return generatedProduct;
		}
	}
}