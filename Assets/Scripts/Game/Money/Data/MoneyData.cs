using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoneyData", menuName = "ScriptableObject/Money")]
public class MoneyData :ScriptableObject
{
    [Header("Parameters")]
    [SerializeField] string name;               // 名前
    [SerializeField] Type type;                 // 小銭、紙幣
    [SerializeField] int value;                 // 値段
    [SerializeField] int generatedCount;        // 最初に生成される数

    [Header("Assets")]
    [SerializeField] Sprite sprite;

    // properties
    public string Name => name;
    public int Value => value;
    public int GeneratedCount => generatedCount;

    public Sprite Sprite => sprite;

    public enum Type {
        coin,   // 小銭
        bill    // 紙幣
    }

    private void OnValidate()
    {
        name = value.ToString() + "Yen";

        if (value == 5 || value == 50 || value == 500) {
            generatedCount = 1;
        }

        else {
            generatedCount = 4;
        }
    }
}
