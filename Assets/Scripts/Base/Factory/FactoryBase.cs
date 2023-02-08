using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryBase : MonoBehaviour
{
	/// <summary>
	/// ê∂ê¨
	/// </summary>
	public abstract ProductBase GetProduct(Vector3 pos, Quaternion rot, Transform parent);
}
