using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoneyData", menuName = "ScriptableObject/Money")]
public class MoneyData :ScriptableObject
{
    [Header("Parameters")]
    [SerializeField] string name;               // 名前
    [SerializeField] int number;                // 識別番号
    [SerializeField] Type type;                 // 小銭、紙幣
    [SerializeField] int amount;                 // 値段
    [SerializeField] int generatedCount;        // 最初に生成される数

    [Header("Assets")]
    [SerializeField] Sprite sprite;

    // properties
    public string Name => name;
    public int Number => number;

    public int Amount => amount;
    public int GeneratedCount => generatedCount;

    public Sprite Sprite => sprite;

    public enum Type {
        coin,   // 小銭
        bill    // 紙幣
    }

    private void OnValidate()
    {
        name = amount.ToString() + "Yen";

        if (amount == 5 || amount == 50 || amount == 500) {
            generatedCount = 1;
        }

        else {
            generatedCount = 4;
        }
    }
}
