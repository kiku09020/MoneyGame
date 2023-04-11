using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System.Threading;

public class MoneyGenerator : MonoBehaviour
{
	[SerializeField] int waitFrame = 10;
	[SerializeField] float moveToGroupDuration = 0.1f;
	[SerializeField] float alignmentMoveDuration = 0.1f;


	[Serializable]
	class MoneyUnit {
		public string name;
		[SerializeField] Money money;

		[Header("MoneyGroups")]
		[SerializeField, Tooltip("�ڕW�̏������O���[�v")] MoneyGroup targetPlayerMG;
		[SerializeField, Tooltip("�ڕW�̎x�����O���[�v")] MoneyGroup targetPaymentMG;

		public Money Money => money;
		public MoneyGroup TargetPlayerMG => targetPlayerMG;
		public MoneyGroup TargetPaymentMG => targetPaymentMG;
	}

    [SerializeField] List<MoneyUnit> moneyUnitList = new List<MoneyUnit>();

	CancellationToken token;

    //--------------------------------------------------

    private void Awake()
    {
		token = this.GetCancellationTokenOnDestroy();
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
	public async void GenerateAndMove()
	{
		await UniTask.Delay(1, cancellationToken: token);

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
				var prevPos = moneyObjList[count].RectTransform.position;


				moneyObjList[count].transform.SetParent(moneyUnit.TargetPlayerMG.transform);                 // �ړ���ɐe�Ɏw�肷��
				var targetPos = moneyObjList[count].RectTransform.position;

				moneyObjList[count].RectTransform.position = prevPos;

				await UniTask.DelayFrame(waitFrame, cancellationToken: token);

				moneyObjList[count].RectTransform.DOLocalMove(-targetPos, alignmentMoveDuration);

				count++;
			}
		}
    }
}
