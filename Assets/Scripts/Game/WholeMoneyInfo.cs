using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.AssetImporters;

public class WholeMoneyInfo : SimpleSingleton<WholeMoneyInfo>
{
	[SerializeField,Tooltip("最初のお金の最大枚数")] int startPocketMoneyMaxCount;

	[SerializeField,Tooltip("目標額の指定タイプ")] TargetMoneyType targetMoneyType;
	

	// 目標額のタイプ
	public enum TargetMoneyType
	{
		constant,				// 定数
		random,					// ランダム値
		randomWithScore,		// スコアに応じた範囲内のランダム値
	}

	[SerializeField] int minTargetMoneyAmount = 200;
	[SerializeField] int maxTargetMoneyAmount = 500;

	/// <summary>
	/// 所持金の最大枚数
	/// </summary>
	public int PocketMoneyMaxCount { get; private set; }

	/// <summary>
	/// 目標額
	/// </summary>
	public int TargetMoneyAmount { get; private set; }

	//--------------------------------------------------

	private void Start()
	{
		PocketMoneyMaxCount = startPocketMoneyMaxCount;
	}

	//--------------------------------------------------

	/// <summary>
	/// 目標額の範囲指定
	/// </summary>
	public void SetTargetMoneyAmountRegion(int min, int max)
	{
		minTargetMoneyAmount = min;
		maxTargetMoneyAmount = max;
	}

	/// <summary>
	/// 目標額の指定
	/// </summary>
	public void SetTargetMoneyAmount()
	{
		switch (targetMoneyType) { 
			case TargetMoneyType.constant:
				TargetMoneyAmount = 1111;
				break;

				case TargetMoneyType.random:
				TargetMoneyAmount = Random.Range(minTargetMoneyAmount, maxTargetMoneyAmount);
				break;
			}
	}
}
