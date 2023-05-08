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
    public static int ComboCount { get; private set; }

	//--------------------------------------------------

	private void Awake()
	{
		Score = 0; 
        ComboCount = 0;
	}

	/// <summary>
	/// �X�R�A���Z
	/// </summary>
	public static void AddScore(int value)
    {
        Score += value * ComboCount;
    }

    /// <summary>
    /// �R���{���Z
    /// </summary>
	public static void AddCombo()
	{
        ComboCount++;
	}

    /// <summary>
    /// �R���{���Z�b�g
    /// </summary>
    public static void ResetCombo()
    {
        ComboCount = 0;
    }
}
