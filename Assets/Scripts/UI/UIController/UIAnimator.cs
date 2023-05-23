using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIAnimator :MonoBehaviour
{
	[Header("Data")]
	[SerializeField] UIAnimData animData;

	//--------------------------------------------------

	/// <summary>
	/// �A�j���[�V�����̍Đ�
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="uiObject"></param>
	public abstract void Play<T>(T uiObject) where T : ILayoutElement;
}
