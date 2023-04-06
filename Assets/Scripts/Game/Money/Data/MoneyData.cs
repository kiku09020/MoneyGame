using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MoneyData 
{
    [SerializeField] string name;
    [SerializeField] Type type;
    [SerializeField] int value;
    [SerializeField] Texture2D texture;

    public enum Type {
        coin,   // è¨ëK
        bill    // éÜïº
    }
}
