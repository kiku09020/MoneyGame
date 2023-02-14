using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
/// <summary>
/// ログ用のタグ
/// </summary>
public enum LogTag {
    Invalid = -1,
    Debug,
    Scene,
    Audio,
}

public abstract class LogController : MonoBehaviour
{
    public static void Log(object message, LogTag tag = LogTag.Invalid)
    {
        var msg = AddMessageTag(message, tag);

        Debug.Log(msg);
    }

    // 色タグ追加
    static string AddColorTag(object msg, Color color)
    {
        var code = ColorUtility.ToHtmlStringRGBA(color);
        var codeStart = $"<b><color=#{code}>";
        var codeEnd = "</color></b>";

        return codeStart + msg.ToString() + codeEnd;
    }

    // サイズタグ追加
    static string AddSizeTag(object msg,int size)
    {
        var codeStart = $"<b><size={size}>";
        var codeEnd = "</size></b>";

        return codeStart + msg.ToString() + codeEnd;
    }

    // [○○]のようなタグを追加
    static string AddMessageTag(object msg,LogTag tag)
	{
        // タグ無効でなければ[タグ]付与
		if (tag != LogTag.Invalid) {
            return $"[{tag}]" + msg.ToString();
		}

        return msg.ToString();
	}

    /// <summary>
    /// 色付きログ表示
    /// </summary>
    public static void ColoredLog(object message, Color color, LogTag tag = LogTag.Invalid)
    {
        var tagdMsg = AddMessageTag(message, tag);
        var coloredMsg= AddColorTag(tagdMsg, color);

        Debug.Log(coloredMsg);
    }

    /// <summary>
    /// サイズ指定ログ表示
    /// </summary>
    public static void ReSizedLog(object message, int size, LogTag tag = LogTag.Invalid)
    {
        var tagdMsg = AddMessageTag(message, tag);
        var resizedMsg = AddSizeTag(tagdMsg, size);

        Debug.Log(resizedMsg);
    }

    /// <summary>
    /// 色とサイズ指定されたログ表示
    /// </summary>
    public static void ColoredAndResizedLog(object message, Color color, int size, LogTag tag = LogTag.Invalid)
    {
        var tagdMsg = AddMessageTag(message, tag);
        var coloredMsg = AddColorTag(tagdMsg, color);
        var resizedMsg = AddSizeTag(coloredMsg, size);

        Debug.Log(resizedMsg);
    }

    
}
#endif