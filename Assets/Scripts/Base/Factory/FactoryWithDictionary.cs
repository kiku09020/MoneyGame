using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryWithDictionary : FactoryBase
{
	Dictionary<string, ProductBase> generatedProductsDict = new Dictionary<string, ProductBase>();

	/// <summary>
	/// 生成されたオブジェクトのDictionary
	/// </summary>
	public Dictionary<string, ProductBase> GeneratedProductsDict => generatedProductsDict;

	/// <summary>
	/// 生成されたオブジェクトをDictionaryに追加する
	/// </summary>
	protected void AddToGeneratedDict(ProductBase generatedProduct, string key)
	{
		generatedProductsDict.Add(key, generatedProduct);
	}
}
