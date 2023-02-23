using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;


public static class AudioFileNameCreator 
{
    const string CMD_NAME = "Tools/Create/AudioName";                                   // �R�}���h��
    const string EXPORT_PATH = "Assets/Scripts/Manager/Audio/AudioNames.cs";            // �쐬�����X�N���v�g�̃p�X

    static readonly string FILENAME = Path.GetFileNameWithoutExtension(EXPORT_PATH);    // �g���q�Ȃ�
    static readonly string FILENAME_EXT = Path.GetFileName(EXPORT_PATH);                // �g���q����

    // �쐬�\��
    [MenuItem(CMD_NAME, true)]
    static bool CheckCanCreate()
    {
        return !EditorApplication.isPlaying && !EditorApplication.isCompiling;
    }

    //-------------------------------------------

    [MenuItem(CMD_NAME)]
    public static void Create()
    {
        if (CheckCanCreate()) {
            CreateScript();
            Debug.Log($"<color=yellow><b>{typeof(AudioNames).Name}.cs���X�V����܂���</b></color>");
        }
    }


    // �t�@�C�����X�N���v�g�̍쐬
    static void CreateScript()
    {
        var builder = new StringBuilder();

        // ���\�[�X�擾
        object[] bgmList = Resources.LoadAll("Audio/BGM");
        object[] seList = Resources.LoadAll("Audio/SE");

        builder.AppendFormat($"public static class {FILENAME}").AppendLine();
        builder.AppendLine("{");

        CreateFileNames(builder, bgmList, "BGM");   // BGM�̃t�@�C�����쐬
        builder.AppendLine("\t");

        CreateFileNames(builder, seList, "SE");     // SE�̃t�@�C�����쐬
        builder.AppendLine("}");

        SetupScript(builder);
    }

    // �t�@�C�����쐬
    static void CreateFileNames(StringBuilder builder, object[] audioList,string fileHeadName)
    {
        foreach(AudioClip clip in audioList) {
            builder.Append("\t")
                .AppendFormat($@"public const string {fileHeadName}_{clip.name.ToUpper()} = ""{clip.name}"";")
                .AppendLine();
        }
    }

    // �X�N���v�g�쐬����
    static void SetupScript(StringBuilder builder)
    {
        // �w�肳�ꂽ�f�B���N�g����������΁A�V�K�쐬
        var dictName = Path.GetDirectoryName(EXPORT_PATH);

        if (!Directory.Exists(dictName)) {
            Directory.CreateDirectory(dictName);
        }

        File.WriteAllText(EXPORT_PATH, builder.ToString(), Encoding.UTF8);      // �쐬
        AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);              // �A�Z�b�g�X�V����
    }

}
