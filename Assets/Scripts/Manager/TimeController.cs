using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public static class TimeController
{
	/// <summary>
	/// 停止されているか
	/// </summary>
    public static bool IsStoping { get; private set; }

	/// <summary>
	/// 変更されているか
	/// </summary>
	public static bool IsChanged { get; private set; }

	//--------------------------------------------------
	/// <summary>
	/// 時間停止。時間停止中に呼び出すと
	/// </summary>
	public static void Stop()
	{
		// 停止
		Time.timeScale = 0;
		IsStoping = true;
		IsChanged = true;
	}

	/// <summary>
	/// TimeScaleを元に戻す
	/// </summary>
	public static void ResetTimeScale()
	{
		Time.timeScale = 1;
		IsStoping = false;
		IsChanged = false;
	}

	/// <summary>
	/// 目的のTimeScaleに設定
	/// </summary>
	/// <param name="timeScale"></param>
	public static void ChangeTimeScale(float timeScale, bool enableReset = false)
	{
		// 時間を元に戻す
		if (enableReset && IsChanged) {
			ResetTimeScale();
		}

		else {
			// 時間変更
			Time.timeScale = timeScale;
			IsChanged = true;
		}
	}

	//--------------------------------------------------
}
