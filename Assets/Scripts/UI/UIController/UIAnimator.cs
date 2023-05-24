using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameController.UI.UIController {
public class UIAnimator<T> :MonoBehaviour where T:ILayoutElement
{
	//--------------------------------------------------

	/// <summary>
	/// アニメーションの再生
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="uiObject"></param>
	public static void Play(T uiObject, UIAnimData data, Action onCompletedAction = null)
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
	}