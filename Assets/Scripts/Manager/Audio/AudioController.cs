using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioListener))]
public class AudioController : Singleton<AudioController>
{

    /// <summary>
    /// ‘S‚Ä‚Ì‰¹º‚ğˆê’â~
    /// </summary>
    public static void PauseAllAudio()
    {
        BGM.Instance.Pause();
        SE.Instance.Pause();
    }

    /// <summary>
    /// ‘S‚Ä‚Ì‰¹º‚Ìˆê’â~‚ğ‰ğœ
    /// </summary>
    public static void UnPauseAllAudio()
    {
        BGM.Instance.UnPause();
        SE.Instance.UnPause();
    }

    /// <summary>
    /// ‘S‚Ä‚Ì‰¹º‚ğ’â~
    /// </summary>
    public static void StopAllAudio()
    {
        BGM.Instance.Stop();
        SE.Instance.Stop();
    }
}
