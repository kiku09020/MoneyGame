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
	/// ���������ǂ���
	/// </summary>
	public static bool IsGenerating { get; private set; }

	public List<MoneyUnit> MoneyUnitList => moneyUnitList;

	//--------------------------------------------------

	[Serializable]
	public class MoneyUnit {
		public string name;
		[SerializeField] Money money;

		[Header("MoneyGroups")]
		[SerializeField, Tooltip("�ڕW�̏������O���[�v")] MoneyGroup targetPlayerMG;
		[SerializeField, Tooltip("�ڕW�̎x�����O���[�v")] MoneyGroup targetPaymentMG;

		public Money Money => money;
		public MoneyGroup TargetPlayerMG => targetPlayerMG;
		public MoneyGroup TargetPaymentMG => targetPaymentMG;
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
	/// ������Ɉړ�������
	/// </summary>
	public void GenerateAndMove()
	{
		IsGenerating = true;

		if (UIManager.GetUIGroup<GameUIGroup>().gameObject.activeSelf) {
			var moneyObjList = Generate();

			MoveToPlayerMG(moneyObjList);
		}
	}

	// ����
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

	// �v���C���[�̃O���[�v�Ɉړ�������
	void MoveToPlayerMG(List<Money> moneyObjList)
	{
		var count = 0;
		foreach (var moneyUnit in moneyUnitList) {
			for (int j = 0; j < moneyUnit.Money.Data.GeneratedCount; j++) {
				moneyObjList[count].RectTransform.DOLocalMove(moneyUnit.TargetPlayerMG.RectTransform.localPosition, moveToGroupDuration)
					.OnComplete(() => MoveCompleted(moneyObjList));

				count++;
			}
		}
	}

	async void MoveCompleted(List<Money> moneyObjList)
	{
		var count = 0;

		foreach (var moneyUnit in moneyUnitList) {
			for (int i = 0; i < moneyUnit.Money.Data.GeneratedCount; i++) {
				moneyObjList[count].transform.SetParent(moneyUnit.TargetPlayerMG.RectTransform);        // �e�Ɏw�肷��

				await UniTask.DelayFrame(waitFrame,PlayerLoopTiming.FixedUpdate, cancellationToken: token);						// �ҋ@

				count++;
			}
		}

		IsGenerating = false;       // ��������
		state.StateTransition("MainState");		// ���C����ԂɑJ��
	}
}
