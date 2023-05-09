using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// スコア
    /// </summary>
    public static int Score { get; private set; }

    /// <summary>
    /// コンボ数
    /// </summary>
    public static int ComboCount { get; private set; }

	//--------------------------------------------------

	private void Awake()
	{
		Score = 0; 
        ComboCount = 0;
	}

	/// <summary>
	/// スコア加算
	/// </summary>
	public static void AddScore(int value)
    {
        Score += value * ComboCount;
    }

    /// <summary>
    /// コンボ加算
    /// </summary>
	public static void AddCombo()
	{
        ComboCount++;
	}

    /// <summary>
    /// コンボリセット
    /// </summary>
    public static void ResetCombo()
    {
        ComboCount = 0;
    }

	/// <summary>
	/// スコアの桁区切りされた文字列を取得する
	/// </summary>
	/// <returns>スコアの桁区切りされた文字列</returns>
	public static string GetScoreString()
	{
		return string.Format("{0:#,0}", Score);
    }

	/// <summary>
	/// 指定されたスコアを桁区切りした文字列を取得
	/// </summary>
	/// <param name="score">目標スコア</param>
	/// <returns>スコアの桁区切りされた文字列</returns>
	public static string GetScoreString(int score)
    {
		return string.Format("{0:#,0}", score);
	}
}
