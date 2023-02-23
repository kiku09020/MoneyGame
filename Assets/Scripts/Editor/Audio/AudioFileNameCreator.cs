using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;


public static class AudioFileNameCreator 
{
    const string CMD_NAME = "Tools/Create/AudioName";                                   // コマンド名
    const string EXPORT_PATH = "Assets/Scripts/Manager/Audio/AudioNames.cs";            // 作成されるスクリプトのパス

    static readonly string FILENAME = Path.GetFileNameWithoutExtension(EXPORT_PATH);    // 拡張子なし
    static readonly string FILENAME_EXT = Path.GetFileName(EXPORT_PATH);                // 拡張子あり

    // 作成可能か
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
            Debug.Log($"<color=yellow><b>{typeof(AudioNames).Name}.csが更新されました</b></color>");
        }
    }


    // ファイル名スクリプトの作成
    static void CreateScript()
    {
        var builder = new StringBuilder();

        // リソース取得
        object[] bgmList = Resources.LoadAll("Audio/BGM");
        object[] seList = Resources.LoadAll("Audio/SE");

        builder.AppendFormat($"public static class {FILENAME}").AppendLine();
        builder.AppendLine("{");

        CreateFileNames(builder, bgmList, "BGM");   // BGMのファイル名作成
        builder.AppendLine("\t");

        CreateFileNames(builder, seList, "SE");     // SEのファイル名作成
        builder.AppendLine("}");

        SetupScript(builder);
    }

    // ファイル名作成
    static void CreateFileNames(StringBuilder builder, object[] audioList,string fileHeadName)
    {
        foreach(AudioClip clip in audioList) {
            builder.Append("\t")
                .AppendFormat($@"public const string {fileHeadName}_{clip.name.ToUpper()} = ""{clip.name}"";")
                .AppendLine();
        }
    }

    // スクリプト作成処理
    static void SetupScript(StringBuilder builder)
    {
        // 指定されたディレクトリが無ければ、新規作成
        var dictName = Path.GetDirectoryName(EXPORT_PATH);

        if (!Directory.Exists(dictName)) {
            Directory.CreateDirectory(dictName);
        }

        File.WriteAllText(EXPORT_PATH, builder.ToString(), Encoding.UTF8);      // 作成
        AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);              // アセット更新処理
    }

}
