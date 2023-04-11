using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using DG.Tweening;

public class MoneyGenerator : MonoBehaviour
{
	[Serializable]
	class MoneyUnit {
		public string name;
		[SerializeField] Money money;

		[Header("MoneyGroups")]
		[SerializeField, Tooltip("目標の所持金グループ")] MoneyGroup targetPlayerMG;
		[SerializeField, Tooltip("目標の支払いグループ")] MoneyGroup targetPaymentMG;

		public Money Money => money;
		public MoneyGroup TargetPlayerMG => targetPlayerMG;
		public MoneyGroup TargetPaymentMG => targetPaymentMG;
	}

    [SerializeField] List<MoneyUnit> moneyUnitList = new List<MoneyUnit>();

	//--------------------------------------------------

	private void OnValidate()
	{
		foreach(var moneyUnit in moneyUnitList) {
			if (moneyUnit.Money != null && moneyUnit.Money.Data != null) {
				moneyUnit.name = moneyUnit.Money.Data.name;
			}
		}
	}

	/// <summary>
	/// 生成後に移動させる
	/// </summary>
	public void GenerateAndMove()
	{
		var moneyObjList = Generate();

		MoveToPlayerMG(moneyObjList);
	}

	// 生成
	List<Money> Generate()
	{
		var moneyObjList = new List<Money>();

		foreach(var moneyUnit in moneyUnitList) {
			for (int i = 0; i < moneyUnit.Money.Data.GeneratedCount; i++) {
				moneyObjList.Add(Instantiate(moneyUnit.Money, transform));
			}
		}

		return moneyObjList;
	}

	// プレイヤーのグループに移動させる
	void MoveToPlayerMG(List<Money> moneyObjList)
	{
		var count = 0;
		foreach (var moneyUnit in moneyUnitList) {
			for (int j = 0; j < moneyUnit.Money.Data.GeneratedCount; j++) {
				moneyObjList[count].RectTransform.DOAnchorPos(moneyUnit.TargetPlayerMG.RectTransform.anchoredPosition, 1);
				count++;
			}
		}
	}
}
