using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public abstract class DataManagerBase<T> : SimpleSingleton<T> where T : DataManagerBase<T> {
    /// <summary>
    /// ファイルパス
    /// </summary>
    protected string FilePath { get; private set; }

    /// <summary>
    /// ファイル名
    /// </summary>
    protected abstract string FileName { get; }

    const string FOLDER_NAME = "Data";

    //-------------------------------------------

    // ファイルパスの取得
    void GetFilePath()
    {
        var fileNameWithEXT = $"{FileName}.json";     // 拡張子付きファイル名

        var dataPath = "";

#if UNITY_EDITOR
        dataPath = Application.dataPath;

#else
        dataPath = Application.persistentDataPath;

#endif
        var directoryPath = $"{dataPath}/{FOLDER_NAME}";

        // ディレクトリパスがなければ、ディレクトリ新規作成
        if (!Directory.Exists(directoryPath)) {
            Directory.CreateDirectory(directoryPath);
        }

        FilePath = $"{directoryPath}/{fileNameWithEXT}";

    }

    // セットアップ
    protected Data SetUp<Data>(IData data) where Data:IData
    {
        GetFilePath();

        // ファイルが存在しなければ、新規作成
        if (!File.Exists(FilePath)) {
            Save(data);
        }

        return Load<Data>();
    }

    //-------------------------------------------

    // セーブ
    protected void Save(IData data)
    {
        var json = JsonUtility.ToJson(data);
        var wr = new StreamWriter(FilePath, false);

        wr.WriteLine(json);
        wr.Close();
    }

    // ロード
    protected Data Load<Data>() where Data : IData
    {
        var rd = new StreamReader(FilePath);
        var json = rd.ReadToEnd();
        rd.Close();

        return JsonUtility.FromJson<Data>(json);
    }
}
