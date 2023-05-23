using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimator<T> :MonoBehaviour where T:ILayoutElement
{
	//--------------------------------------------------

	/// <summary>
	/// アニメーションの再生
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="uiObject"></param>
	public static void Play(T uiObject, UIAnimData data)
	{

	}

	static void Movement(T obj,UIAnimData data)
	{

	}

	static void Scaling(T obj,UIAnimData data)
	{

	}

	static void Rotation(T obj,UIAnimData data)
	{

	}

	static void Fading(T obj,UIAnimData data)
	{

	}
}
