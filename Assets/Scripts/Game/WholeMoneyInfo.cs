using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.AssetImporters;

public class WholeMoneyInfo : SimpleSingleton<WholeMoneyInfo>
{
	[SerializeField,Tooltip("�ŏ��̂����̍ő喇��")] int startPocketMoneyMaxCount;

	[SerializeField,Tooltip("�ڕW�z�̎w��^�C�v")] TargetMoneyType targetMoneyType;
	

	// �ڕW�z�̃^�C�v
	public enum TargetMoneyType
	{
		constant,				// �萔
		random,					// �����_���l
		randomWithScore,		// �X�R�A�ɉ������͈͓��̃����_���l
	}

	[SerializeField] int minTargetMoneyAmount = 200;
	[SerializeField] int maxTargetMoneyAmount = 500;

	/// <summary>
	/// �������̍ő喇��
	/// </summary>
	public int PocketMoneyMaxCount { get; private set; }

	/// <summary>
	/// �ڕW�z
	/// </summary>
	public int TargetMoneyAmount { get; private set; }

	//--------------------------------------------------

	private void Start()
	{
		PocketMoneyMaxCount = startPocketMoneyMaxCount;
	}

	//--------------------------------------------------

	/// <summary>
	/// �ڕW�z�͈͎̔w��
	/// </summary>
	public void SetTargetMoneyAmountRegion(int min, int max)
	{
		minTargetMoneyAmount = min;
		maxTargetMoneyAmount = max;
	}

	/// <summary>
	/// �ڕW�z�̎w��
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
