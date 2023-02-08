using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryWithList : FactoryBase
{
	List<ProductBase> generatedProductList = new List<ProductBase>();

	/// <summary>
	/// 生成されたオブジェクトのList
	/// </summary>
	public List<ProductBase> GeneratedProductList => generatedProductList;

	/// <summary>
	/// 生成されたオブジェクトをListに追加する
	/// </summary>
	protected void AddToGeneratedList(ProductBase generatedProduct)
	{
		generatedProductList.Add(generatedProduct);
	}
}
