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
	/// ���݂̃X�R�A�ƃn�C�X�R�A���r���āA�n�C�X�R�A���傫����Εۑ�
	/// </summary>
	public void Save()
	{
		// �n�C�X�R�A���傫��������
		if (data.highScore < ScoreManager.Score) {
			data.highScore = ScoreManager.Score;

			Save(data);		// �傫����Εۑ�
		}
	}

	/// <summary>
	/// �n�C�X�R�A�ǂݍ���
	/// </summary>
	public void Load()
	{
		data = Load<GameData>();
	}
}
