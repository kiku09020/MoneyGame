using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoneyData", menuName = "ScriptableObject/Money")]
public class MoneyData :ScriptableObject
{
    [Header("Parameters")]
    [SerializeField] string name;               // ���O
    [SerializeField] Type type;                 // ���K�A����
    [SerializeField] int value;                 // �l�i
    [SerializeField] int generatedCount;        // �ŏ��ɐ�������鐔

    [Header("Assets")]
    [SerializeField] Sprite sprite;

    // properties
    public string Name => name;
    public int Value => value;
    public int GeneratedCount => generatedCount;

    public Sprite Sprite => sprite;

    public enum Type {
        coin,   // ���K
        bill    // ����
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
