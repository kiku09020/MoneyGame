using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���O�p�̃^�O
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

    // �F�^�O�ǉ�
    static string AddColorTag(object msg, Color color)
    {
        var code = ColorUtility.ToHtmlStringRGBA(color);
        var codeStart = $"<b><color=#{code}>";
        var codeEnd = "</color></b>";

        return codeStart + msg.ToString() + codeEnd;
    }

    // �T�C�Y�^�O�ǉ�
    static string AddSizeTag(object msg,int size)
    {
        var codeStart = $"<b><size={size}>";
        var codeEnd = "</size></b>";

        return codeStart + msg.ToString() + codeEnd;
    }

    // [����]�̂悤�ȃ^�O��ǉ�
    static string AddMessageTag(object msg,LogTag tag)
	{
        // �^�O�����łȂ����[�^�O]�t�^
		if (tag != LogTag.Invalid) {
            return $"[{tag}]" + msg.ToString();
		}

        return msg.ToString();
	}

    /// <summary>
    /// �F�t�����O�\��
    /// </summary>
    public static void ColoredLog(object message, Color color, LogTag tag = LogTag.Invalid)
    {
        var tagdMsg = AddMessageTag(message, tag);
        var coloredMsg= AddColorTag(tagdMsg, color);

        Debug.Log(coloredMsg);
    }

    /// <summary>
    /// �T�C�Y�w�胍�O�\��
    /// </summary>
    public static void ReSizedLog(object message, int size, LogTag tag = LogTag.Invalid)
    {
        var tagdMsg = AddMessageTag(message, tag);
        var resizedMsg = AddSizeTag(tagdMsg, size);

        Debug.Log(resizedMsg);
    }

    /// <summary>
    /// �F�ƃT�C�Y�w�肳�ꂽ���O�\��
    /// </summary>
    public static void ColoredAndResizedLog(object message, Color color, int size, LogTag tag = LogTag.Invalid)
    {
        var tagdMsg = AddMessageTag(message, tag);
        var coloredMsg = AddColorTag(tagdMsg, color);
        var resizedMsg = AddSizeTag(coloredMsg, size);

        Debug.Log(resizedMsg);
    }

    
}