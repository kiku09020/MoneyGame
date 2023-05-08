using System.Collections.Generic;
using UnityEngine;
using GameController;

public class MoneyGenerator : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] GameStateMachine state;
	[SerializeField] WholeMoneyInfo wholeMoneyInfo;

	Money bill => wholeMoneyInfo.MoneyUnitList[6].Money;

	//--------------------------------------------------
	// Proparties
	/// <summary>
	/// 生成中かどうか
	/// </summary>
	public static bool IsGenerating { get; private set; }

	//--------------------------------------------------

	private void OnDisable()
	{
		IsGenerating = false;
	}

	private void OnValidate()
	{
		foreach(var moneyUnit in wholeMoneyInfo.MoneyUnitList) {
			if (moneyUnit.Money != null && moneyUnit.Money.Data != null) {
				moneyUnit.name = moneyUnit.Money.Data.name;
			}
		}
	}

	//--------------------------------------------------

	/// <summary>
	/// 生成後に移動させる
	/// </summary>
	public async void GenerateAndMove()
	{
		IsGenerating = true;

		if (UIManager.GetUIGroup<GameUIGroup>().gameObject.activeSelf) {
			var moneyObjList = Generate();

			foreach(var money in moneyObjList) {
				await money.Mover.MoveToCurrentMG(false, false, true);
			}

			IsGenerating = false;       // 生成完了
		}
	}

	/// <summary>
	/// おつりの移動
	/// </summary>
	/// <param name="changes"></param>
	public async void GenerateAndMoveChange(List<WholeMoneyCalculator.ChangeMoneyUnit> changes, Transform parent)
	{
		var changeMoneyList = GenerateChange(changes, parent);

		for (int i = changeMoneyList.Count - 1; i >= 0; i--) {
			await changeMoneyList[i].Mover.MoveToCurrentMG(false, false, true);
		}
	}

	//--------------------------------------------------

	// 生成
	List<Money> Generate()
	{
		var moneyObjList = new List<Money>();

		foreach(var moneyUnit in wholeMoneyInfo.MoneyUnitList) {
			// インスタンス化されたお金をリストに追加
			for (int i = 0; i < moneyUnit.Money.Data.GeneratedCount; i++) {
				var obj = Instantiate(moneyUnit.Money, transform);
				obj.Generated(moneyUnit.PocketMG);
				moneyObjList.Add(obj);			
			}
		}

		return moneyObjList;		// インスタンス化されたお金のリストを返す
	}

	/// <summary>
	/// おつりの生成
	/// </summary>
	List<Money> GenerateChange(List<WholeMoneyCalculator.ChangeMoneyUnit> changes,Transform parent)
	{
		var moneyObjList = new List<Money>();

		foreach(var changeUnit in changes) {
			foreach(var change in changeUnit.MoneyList) {
				var obj = Instantiate(change.Money, parent);		// 生成
				obj.Generated(change.PocketMG);						// 生成されたときの処理
				moneyObjList.Add(obj);								// リストに追加
			}
		}

		return moneyObjList;
	}

	//--------------------------------------------------

	/// <summary>
	/// お札の生成、移動
	/// </summary>
	public async void GenerateAndMoveBill(MoneyGroupUnit moneyGroupUnit)
	{
		var billObj = Instantiate(bill,transform);
		billObj.Generated(moneyGroupUnit);
		await billObj.Mover.MoveBase(moneyGroupUnit, false, false, true);
	}
}
