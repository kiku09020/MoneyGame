using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

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

	/// <summary>
	/// �X�R�A�̌���؂肳�ꂽ��������擾����
	/// </summary>
	/// <returns>�X�R�A�̌���؂肳�ꂽ������</returns>
	public static string GetScoreString()
	{
		return string.Format("{0:#,0}", Score);
    }

	/// <summary>
	/// �w�肳�ꂽ�X�R�A������؂肵����������擾
	/// </summary>
	/// <param name="score">�ڕW�X�R�A</param>
	/// <returns>�X�R�A�̌���؂肳�ꂽ������</returns>
	public static string GetScoreString(int score)
    {
		return string.Format("{0:#,0}", score);
	}
}
