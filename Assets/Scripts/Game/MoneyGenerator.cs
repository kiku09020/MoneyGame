using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System.Threading;
using GameController;

public class MoneyGenerator : MonoBehaviour
{
	[Header("Parameters")]
	[SerializeField] int waitFrame = 10;
	[SerializeField] float moveToGroupDuration = 0.1f;
	[SerializeField] float alignmentMoveDuration = 0.1f;

	[Header("Components")]
	[SerializeField] GameStateMachine state;

	[Header("MoneyList")]
	[SerializeField] List<MoneyUnit> moneyUnitList = new List<MoneyUnit>();

	//--------------------------------------------------

	// Proparties
	/// <summary>
	/// 生成中かどうか
	/// </summary>
	public static bool IsGenerating { get; private set; }

	public List<MoneyUnit> MoneyUnitList => moneyUnitList;

	//--------------------------------------------------

	[Serializable]
	public class MoneyUnit {
		public string name;
		[SerializeField] Money money;

		[Header("MoneyGroups")]
		[SerializeField, Tooltip("目標の所持金グループ")] MoneyGroupUnit targetPlayerMG;
		[SerializeField, Tooltip("目標の支払いグループ")] MoneyGroupUnit targetPaymentMG;

		public Money Money => money;
		public MoneyGroupUnit PlayerMG => targetPlayerMG;
		public MoneyGroupUnit PaymentMG => targetPaymentMG;
	}

	CancellationToken token;

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
		IsGenerating = true;

		if (UIManager.GetUIGroup<GameUIGroup>().gameObject.activeSelf) {
			var moneyObjList = Generate();

			MoveToPlayerMG(moneyObjList);
		}
	}

	// 生成
	List<Money> Generate()
	{
		var moneyObjList = new List<Money>();

		foreach(var moneyUnit in moneyUnitList) {
			for (int i = 0; i < moneyUnit.Money.Data.GeneratedCount; i++) {
				moneyUnit.Money.Generated(MoneyUnitList);
				moneyObjList.Add(Instantiate(moneyUnit.Money, transform));
			}
		}

		return moneyObjList;
	}

	// プレイヤーのグループに移動させる
	void MoveToPlayerMG(List<Money> moneyObjList)
	{
		var generatedCount = 0;
		foreach (var moneyUnit in moneyUnitList) {
			for (int j = 0; j < moneyUnit.Money.Data.GeneratedCount; j++) {
				var moneyObj = moneyObjList[generatedCount];

				moneyObj.ChangeCurrentMoneyGroup(moneyObj.PlayerMG, moneyObj.PaymentMG);		// 現在のMGを所持金、目標のMGを支払額として設定
				moneyObj.CurrentMG.MoneyList.Add(moneyObj);										// MGのリストにmoneyObjを追加

				moneyObj.AddButtonActions();													// ButtonにActionを追加

				// 移動
				moneyObjList[generatedCount].RectTransform.DOLocalMove(moneyUnit.PlayerMG.RectTransform.localPosition, moveToGroupDuration)
					.OnComplete(() => MoveCompleted(moneyObjList));

				generatedCount++;		// 生成数加算
			}
		}
	}

	async void MoveCompleted(List<Money> moneyObjList)
	{
		var generatedCount = 0;

		foreach (var moneyUnit in moneyUnitList) {
			for (int i = 0; i < moneyUnit.Money.Data.GeneratedCount; i++) {
				var moneyObj = moneyObjList[generatedCount];

				moneyObj.transform.SetParent(moneyObj.CurrentMG.RectTransform);           // 親に指定する


				await UniTask.DelayFrame(waitFrame,PlayerLoopTiming.FixedUpdate, cancellationToken: token);						// 待機

				generatedCount++;
			}
		}

		IsGenerating = false;       // 生成完了
		state.StateTransition("MainState");		// メイン状態に遷移
	}
}
