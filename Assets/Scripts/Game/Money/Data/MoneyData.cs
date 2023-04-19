using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoneyData", menuName = "ScriptableObject/Money")]
public class MoneyData :ScriptableObject
{
    [Header("Parameters")]
    [SerializeField] string name;               // ���O
    [SerializeField] int number;                // ���ʔԍ�
    [SerializeField] Type type;                 // ���K�A����
    [SerializeField] int amount;                 // �l�i
    [SerializeField] int generatedCount;        // �ŏ��ɐ�������鐔

    [Header("Assets")]
    [SerializeField] Sprite sprite;

    // properties
    public string Name => name;
    public int Number => number;

    public int Amount => amount;
    public int GeneratedCount => generatedCount;

    public Sprite Sprite => sprite;

    public enum Type {
        coin,   // ���K
        bill    // ����
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
