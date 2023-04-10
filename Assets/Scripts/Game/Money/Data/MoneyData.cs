using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoneyData", menuName = "ScriptableObject/Money")]
public class MoneyData :ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] Type type;
    [SerializeField] int value;
    [SerializeField] Texture2D texture;

    public string Name => name;

    public enum Type {
        coin,   // ¬‘K
        bill    // †•¼
    }
}
