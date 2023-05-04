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
    public static int Combo { get; private set; }

	//--------------------------------------------------

	private void Awake()
	{
		Score = 0; 
        Combo = 0;
	}

	/// <summary>
	/// スコア加算
	/// </summary>
	public static void AddScore(int value)
    {
        Score += value * Combo;
    }

    /// <summary>
    /// コンボ加算
    /// </summary>
	public static void AddCombo()
	{
        Combo++;
	}

    /// <summary>
    /// コンボリセット
    /// </summary>
    public static void ResetCombo()
    {
        Combo = 0;
    }
}
