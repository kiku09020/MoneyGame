using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGroupMover : MonoBehaviour
{
    [SerializeField] MoneyGroup moneyGroup;

    //--------------------------------------------------

    /// <summary>
    /// �ڕW��MoneyGroup�܂ňړ�������
    /// </summary>
    /// <param name="changeCurrentMG">money�̌��݂�MoneyGroup�����ւ��邩</param>
    /// <param name="removeTargetMoney">MoneyGroup�̂��������炷��</param>
    /// <param name="wait">�ҋ@���邩</param>
    public async void MoveToTarget(bool changeCurrentMG = true, bool removeTargetMoney = false, bool wait = true)
    {
        foreach(var moneyGroupUnit in moneyGroup.MoneyGroupUnitList) {
			for (int i = moneyGroupUnit.MoneyList.Count - 1; i >= 0; i--) {
                await moneyGroupUnit.MoneyList[i].Mover.MoveToTargetMG(changeCurrentMG, removeTargetMoney, wait);
            }
		}
    }

	/// <summary>
	/// ���݂�MoneyGroup�܂ňړ�������
	/// </summary>
	/// <param name="changeCurrentMG">money�̌��݂�MoneyGroup�����ւ��邩</param>
	/// <param name="removeTargetMoney">MoneyGroup�̂��������炷��</param>
	/// <param name="wait">�ҋ@���邩</param>
	public async void MoveToCurrentMG(bool changeCurrentMG = true, bool removeTargetMoney = false, bool wait = true)
    {
		foreach (var moneyGroupUnit in moneyGroup.MoneyGroupUnitList) {
			for (int i = moneyGroupUnit.MoneyList.Count - 1; i >= 0; i--) {
				await moneyGroupUnit.MoneyList[i].Mover.MoveToCurrentMG(changeCurrentMG, removeTargetMoney, wait);
			}
		}
	}

	/// <summary>
	/// �ړI��Transform�܂ňړ�����
	/// </summary>
	/// <param name="targetTransform">�ړI��Transform</param>
	/// <param name="wait">�ҋ@���邩</param>
	public async void MoveToTargetTransform(Transform targetTransform, bool wait = true)
    {
		foreach (var moneyGroupUnit in moneyGroup.MoneyGroupUnitList) {
			for (int i = moneyGroupUnit.MoneyList.Count - 1; i >= 0; i--) {
				await moneyGroupUnit.MoneyList[i].Mover.MGMoneyToTargetRect(targetTransform, wait);
			}
		}
	}
}
