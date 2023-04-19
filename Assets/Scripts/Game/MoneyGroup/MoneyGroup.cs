using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGroup : MonoBehaviour
{
    int moneyCount;     // �����̖���
    int moneyAmount;    // �����̍��v���z

    [SerializeField] MoneyGroup targetMoneyGroup;
    [SerializeField] List<MoneyGroupUnit> moneyGroups = new List<MoneyGroupUnit>();

    // properties
    public int MoneyCount => moneyCount;
    public int MoneyAmount => moneyAmount;

    //--------------------------------------------------

    void Awake()
    {
        // �����MGUnit���Z�b�g����
        for(int i = 0; i < moneyGroups.Count; i++) {
            moneyGroups[i].SetMoenyGroups(this, targetMoneyGroup.moneyGroups[i]);
        }
    }

	/// <summary>
	/// ���������Z����
	/// </summary>
	/// <param name="count">���Z���閇��</param>
	/// <param name="removeTargetMG">����̖������猸�Z���邩</param>
	public void AddCount(int count = 1, bool removeTargetMG = true)
    {
        moneyCount += count;

        // �t���O�������Ă���΁A�Е��̖��������Z����
        if(removeTargetMG) {
            targetMoneyGroup?.AddCount(-count,false);
        }
    }

    /// <summary>
    /// ���z�����Z����
    /// </summary>
    /// <param name="amount">���Z������z</param>
    /// <param name="removeTargetMG">����̋��z���猸�Z���邩</param>
    public void AddAmount(int amount, bool removeTargetMG = true)
    {
        moneyAmount += amount;

		// �t���O�������Ă���΁A�Е��̋��z�����Z����
		if (removeTargetMG) {
            targetMoneyGroup?.AddAmount(-amount,false);
        }
    }
}
