using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//データインターフェース
public interface IData { }

/// <summary>
/// セーブデータ
/// </summary>
[System.Serializable]
public class SaveData : IData {

}

/// <summary>
/// 設定データ
/// </summary>
[System.Serializable]
public class SettingData : IData { 
    public bool isValidBGM;     // BGMの有効/無効
    public bool isValidSE;      // SEの有効/無効
}

