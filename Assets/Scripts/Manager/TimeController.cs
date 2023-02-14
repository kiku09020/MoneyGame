using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeController
{
	/// <summary>
	/// ’â~‚³‚ê‚Ä‚¢‚é‚©
	/// </summary>
    public static bool IsStoping { get; private set; }

	/// <summary>
	/// •ÏX‚³‚ê‚Ä‚¢‚é‚©
	/// </summary>
	public static bool IsChanged { get; private set; }

	//--------------------------------------------------
	/// <summary>
	/// ŠÔ’â~
	/// </summary>
	public static void Stop(bool isStop)
	{
		Time.timeScale = 0;
		IsStoping = true;
		IsChanged = true;
	}

	/// <summary>
	/// ŠÔ’â~BŠÔ’â~’†‚ÉŒÄ‚Ño‚·‚ÆA’â~I—¹
	/// </summary>
	public static void Stop()
	{
		// ’â~I—¹
		if (IsStoping) {
			ResetTimeScale();
		}

		// ’â~
		else {
			Time.timeScale = 0;
			IsStoping = true;
			IsChanged = true;
		}
	}

	/// <summary>
	/// TimeScale‚ğŒ³‚É–ß‚·
	/// </summary>
	public static void ResetTimeScale()
	{
		Time.timeScale = 1;
		IsStoping = false;
		IsChanged = false;
	}

	/// <summary>
	/// –Ú“I‚ÌTimeScale‚Éİ’è
	/// </summary>
	/// <param name="timeScale"></param>
	public static void ChangeTimeScale(float timeScale, bool enableReset = false)
	{
		// ŠÔ‚ğŒ³‚É–ß‚·
		if (enableReset && IsChanged) {
			ResetTimeScale();
		}

		else {
			// ŠÔ•ÏX
			Time.timeScale = timeScale;
			IsChanged = true;
		}
	}
}
