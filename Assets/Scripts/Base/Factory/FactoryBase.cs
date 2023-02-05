using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryBase : MonoBehaviour
{
	List<IProduct> generatedObjectList = new List<IProduct>();

	/// <summary>
	/// 生成されたオブジェクトのリスト
	/// </summary>
	public List<IProduct> GeneratedObjectList => generatedObjectList;

	/// <summary>
	/// 生成
	/// </summary>
	public abstract IProduct GetProduct(Vector3 pos, Quaternion rot, Transform parent);

	/// <summary>
	/// 生成されたオブジェクトをリストに追加する
	/// </summary>
	protected virtual void AddToGeneratedList(IProduct generatedObj)
	{
		generatedObjectList.Add(generatedObj);
	}
}
