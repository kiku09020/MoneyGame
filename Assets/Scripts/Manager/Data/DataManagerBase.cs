using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public abstract class DataManagerBase<T> : SimpleSingleton<T> where T : DataManagerBase<T> {
    /// <summary>
    /// �t�@�C���p�X
    /// </summary>
    protected string FilePath { get; private set; }

    /// <summary>
    /// �t�@�C����
    /// </summary>
    protected abstract string FileName { get; }

    const string FOLDER_NAME = "Data";

    //-------------------------------------------

    // �t�@�C���p�X�̎擾
    void GetFilePath()
    {
        var fileNameWithEXT = $"{FileName}.json";     // �g���q�t���t�@�C����

        var dataPath = "";

#if UNITY_EDITOR
        dataPath = Application.dataPath;

#else
        dataPath = Application.persistentDataPath;

#endif
        var directoryPath = $"{dataPath}/{FOLDER_NAME}";

        // �f�B���N�g���p�X���Ȃ���΁A�f�B���N�g���V�K�쐬
        if (!Directory.Exists(directoryPath)) {
            Directory.CreateDirectory(directoryPath);
        }

        FilePath = $"{directoryPath}/{fileNameWithEXT}";

    }

    // �Z�b�g�A�b�v
    protected Data SetUp<Data>(IData data) where Data:IData
    {
        GetFilePath();

        // �t�@�C�������݂��Ȃ���΁A�V�K�쐬
        if (!File.Exists(FilePath)) {
            Save(data);
        }

        return Load<Data>();
    }

    //-------------------------------------------

    // �Z�[�u
    protected void Save(IData data)
    {
        var json = JsonUtility.ToJson(data);
        var wr = new StreamWriter(FilePath, false);

        wr.WriteLine(json);
        wr.Close();
    }

    // ���[�h
    protected Data Load<Data>() where Data : IData
    {
        var rd = new StreamReader(FilePath);
        var json = rd.ReadToEnd();
        rd.Close();

        return JsonUtility.FromJson<Data>(json);
    }
}
