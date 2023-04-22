using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MovementParams {
	[SerializeField] float duration = 0.25f;
	[SerializeField] Ease easeType = Ease.Unset;

	public float Duration => duration;
	public Ease EaseType => easeType;	
}
