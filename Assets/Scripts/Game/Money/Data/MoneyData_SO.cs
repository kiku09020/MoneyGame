using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MoneyData",menuName ="ScriptableObject/Money")]
public class MoneyData_SO : ScriptableObject
{
    [SerializeField] List<MoneyData> moneyDatas = new List<MoneyData>();

    //--------------------------------------------------
}
