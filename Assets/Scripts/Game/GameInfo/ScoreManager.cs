using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
