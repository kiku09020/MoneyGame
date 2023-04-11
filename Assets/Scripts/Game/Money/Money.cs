using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Money:MonoBehaviour
{
	[Header("Data")]
    [SerializeField] MoneyData data;

	[Header("Components")]
	[SerializeField] RectTransform rectTransform;
	[SerializeField] Image image;

    // Proparties
    public MoneyData Data => data;
	public RectTransform RectTransform => rectTransform;

	//--------------------------------------------------

	private void OnValidate()
	{
		if (data != null) {
			image.sprite = data.Sprite;
		}
	}
}
