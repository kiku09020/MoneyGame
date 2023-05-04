using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// �X�R�A
    /// </summary>
    public static int Score { get; private set; }

    /// <summary>
    /// �R���{��
    /// </summary>
    public static int Combo { get; private set; }

	//--------------------------------------------------

	private void Awake()
	{
		Score = 0; 
        Combo = 0;
	}

	/// <summary>
	/// �X�R�A���Z
	/// </summary>
	public static void AddScore(int value)
    {
        Score += value * Combo;
    }

    /// <summary>
    /// �R���{���Z
    /// </summary>
	public static void AddCombo()
	{
        Combo++;
	}

    /// <summary>
    /// �R���{���Z�b�g
    /// </summary>
    public static void ResetCombo()
    {
        Combo = 0;
    }
}
