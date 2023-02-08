using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LogController : MonoBehaviour
{
    public static void Log(object message)
    {
        Debug.Log(message);
    }

    // 色タグ追加
    static string AddColorTag(string str, Color color)
    {
        var code = ColorUtility.ToHtmlStringRGBA(color);
        var startStr = $"<color=#{code}>";
        var endStr = "</color>";

        return startStr + str + endStr;
    }

    // サイズタグ追加
    static string AddSizeTag(string str,int size)
    {
        var startStr = $"<size={size}>";
        var endStr = "</size>";

        return startStr + str + endStr;
    }

    /// <summary>
    /// 色付きログ表示
    /// </summary>
    public static void ColoredLog(object message,Color color)
    {
        var str= AddColorTag(message.ToString(), color);

        Debug.Log(str);
    }

    /// <summary>
    /// サイズ指定ログ表示
    /// </summary>
    public static void ReSizedLog(object message,int size)
    {
        var str = AddSizeTag(message.ToString(), size);

        Debug.Log(str);
    }

    /// <summary>
    /// 色とサイズ指定されたログ表示
    /// </summary>
    public static void ColoredAndResizedLog(object message,Color color, int size)
    {
        var coloredStr = AddColorTag(message.ToString(), color);
        var str = AddSizeTag(coloredStr, size);

        Debug.Log(str);
    }

    
}
