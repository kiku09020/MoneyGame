using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathExtention
{
	/// <summary>
	/// 符号の文字列を取得する
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public static string GetSignStr(float value) 
	{
		return (value >= 0) ? "+" : "-";
	}
}
