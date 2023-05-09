using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameDataManager : DataManagerBase<GameDataManager>
{
	protected override string FileName => "GameData";

	[HideInInspector] public GameData data;

	public GameData GameData=> data;

	//--------------------------------------------------

	protected override void Awake()
	{
		base.Awake();

		data = SetUp<GameData>(data);
	}

	/// <summary>
	/// 現在のスコアとハイスコアを比較して、ハイスコアより大きければ保存
	/// </summary>
	public void Save()
	{
		// ハイスコアより大きいか判定
		if (data.highScore < ScoreManager.Score) {
			data.highScore = ScoreManager.Score;

			Save(data);		// 大きければ保存
		}
	}

	/// <summary>
	/// ハイスコア読み込み
	/// </summary>
	public void Load()
	{
		data = Load<GameData>();
	}
}
