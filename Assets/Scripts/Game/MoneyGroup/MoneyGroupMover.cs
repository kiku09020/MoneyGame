using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGroupMover : MonoBehaviour
{
    [SerializeField] MoneyGroup moneyGroup;

    //--------------------------------------------------

    /// <summary>
    /// 目標のMoneyGroupまで移動させる
    /// </summary>
    /// <param name="changeCurrentMG">moneyの現在のMoneyGroupを入れ替えるか</param>
    /// <param name="removeTargetMoney">MoneyGroupのお金を減らすか</param>
    /// <param name="wait">待機するか</param>
    public async void MoveToTarget(bool changeCurrentMG = true, bool removeTargetMoney = false, bool wait = true)
    {
        foreach(var moneyGroupUnit in moneyGroup.MoneyGroupUnitList) {
			for (int i = moneyGroupUnit.MoneyList.Count - 1; i >= 0; i--) {
                await moneyGroupUnit.MoneyList[i].Mover.MoveToTargetMG(changeCurrentMG, removeTargetMoney, wait);
            }
		}
    }

	/// <summary>
	/// 現在のMoneyGroupまで移動させる
	/// </summary>
	/// <param name="changeCurrentMG">moneyの現在のMoneyGroupを入れ替えるか</param>
	/// <param name="removeTargetMoney">MoneyGroupのお金を減らすか</param>
	/// <param name="wait">待機するか</param>
	public async void MoveToCurrentMG(bool changeCurrentMG = true, bool removeTargetMoney = false, bool wait = true)
    {
		foreach (var moneyGroupUnit in moneyGroup.MoneyGroupUnitList) {
			for (int i = moneyGroupUnit.MoneyList.Count - 1; i >= 0; i--) {
				await moneyGroupUnit.MoneyList[i].Mover.MoveToCurrentMG(changeCurrentMG, removeTargetMoney, wait);
			}
		}
	}

	/// <summary>
	/// 目的のTransformまで移動する
	/// </summary>
	/// <param name="targetTransform">目的のTransform</param>
	/// <param name="wait">待機するか</param>
	public async void MoveToTargetTransform(Transform targetTransform, bool wait = true)
    {
		foreach (var moneyGroupUnit in moneyGroup.MoneyGroupUnitList) {
			for (int i = moneyGroupUnit.MoneyList.Count - 1; i >= 0; i--) {
				await moneyGroupUnit.MoneyList[i].Mover.MGMoneyToTargetRect(targetTransform, wait);
			}
		}
	}
}
