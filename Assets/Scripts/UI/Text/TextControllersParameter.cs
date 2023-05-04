using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName ="TextControllersParameter",menuName ="ScriptableObject/TextControllersParameter")]
public class TextControllersParameter : ScriptableObject
{

	//--------------------------------------------------

	// 遅延
	[SerializeField] public float delay;

	// フェード
	[SerializeField] public bool	colorable;
	[SerializeField] public Color	targetColor;

	[SerializeField] public bool	fadable;
	[SerializeField] public float	inDuration		= .25f;
	[SerializeField] public float	outDuration		= .25f;
	[SerializeField] public float	normalDuration	= .5f;

	// 移動
	[SerializeField] public bool	movable;
	[SerializeField] public float	movingDuration	= .5f;
	[SerializeField] public Vector2 startPosition;
	[SerializeField] public Vector2 targetPosition;
	[SerializeField] public Ease	movingEaseType;

	// サイズ
	[SerializeField] public bool	scalable;
	[SerializeField] public float	scalingDuration	= .5f;
	[SerializeField] public Vector2 targetScale	= Vector2.one;
	[SerializeField] public Ease	scalingEaseType;
}
