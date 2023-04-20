using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System.Threading;
using GameController;
using System.Net.Sockets;

public class MoneyGenerator : MonoBehaviour
{
	[Header("Parameters")]
	[SerializeField] int waitFrame = 10;
	[SerializeField] float moveToGroupDuration = 0.1f;

	[Header("Change")]
	[SerializeField] Transform generatedTransform;

	[Header("Components")]
	[SerializeField] GameStateMachine state;
	[SerializeField] WholeMoneyInfo wholeMoneyInfo; 

	CancellationToken token;

	//--------------------------------------------------
	// Proparties
	/// <summary>
	/// 生成中かどうか
	/// </summary>
	public static bool IsGenerating { get; private set; }

	//--------------------------------------------------

    private void Awake()
    {
		token = this.GetCancellationTokenOnDestroy();
    }

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
				money.Mover.MoveToCurrentMG(false);

				await UniTask.DelayFrame(waitFrame, PlayerLoopTiming.FixedUpdate, cancellationToken: token);
			}

			IsGenerating = false;       // 生成完了
			state.StateTransition("MainState");     // メイン状態に遷移
		}
	}

	/// <summary>
	/// おつりの移動
	/// </summary>
	/// <param name="changes"></param>
	public async void GenerateAndMoveChange(List<WholeMoneyCalculator.changeMoneyUnit> changes)
	{
		foreach (var money in (GenerateChange(changes))) {
			money.Mover.MoveToCurrentMG(false);

			await UniTask.DelayFrame(waitFrame, PlayerLoopTiming.FixedUpdate, cancellationToken: token);
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
	List<Money> GenerateChange(List<WholeMoneyCalculator.changeMoneyUnit> changes)
	{
		var moneyObjList = new List<Money>();

		foreach(var change in changes) {
			for (int i = 0; i < change.count; i++) {
				var obj = Instantiate(change.moneyUnit.Money, generatedTransform);
				obj.Generated(change.moneyUnit.PocketMG);
				moneyObjList.Add(obj);
			}
		}

		return moneyObjList;
	}

	//--------------------------------------------------
}
