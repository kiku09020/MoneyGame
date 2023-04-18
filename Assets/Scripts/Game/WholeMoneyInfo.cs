using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WholeMoneyInfo : MonoBehaviour
{
	// Amount

	/// <summary>
	/// �ڕW�̎x���z
	/// </summary>
	public static int TargetPaymentAmount { get; private set; }

	/// <summary>
	/// ���݂̎x���z
	/// </summary>
	public static int CurrentPaymentAmount { get; private set; }

	/// <summary>
	/// ���݂̏�����
	/// </summary>
	public static int CurrentPocketAmount { get; private set; }

	// Count

	/// <summary>
	/// PaymentMG�ɑ��݂���Money�̐�
	/// </summary>
	public static int CurrentPaymentCount { get; private set; }

	/// <summary>
	/// PlayerMG�ɑ��݂���Money�̐�
	/// </summary>
	public static int CurrentPocketCount { get; private set; }


    //--------------------------------------------------

    void Awake()
    {
        TargetPaymentAmount = 0;
		CurrentPaymentAmount = 0;
		CurrentPocketAmount = 0;

		CurrentPaymentCount = 0;
		CurrentPocketCount = 0;
    }

	//--------------------------------------------------

	/// <summary>
	/// ���݂̎x���z�ɉ��Z����
	/// </summary>
	public static void AddToCurrentPaymentAmount(int amount)
	{
		CurrentPaymentAmount += amount;
	}

	/// <summary>
	/// ���݂̏������ɉ��Z����
	/// </summary>
	public static void AddToCurrentPocketAmount(int amount)
	{
		CurrentPocketAmount += amount;
	}

	//--------------------------------------------------
	/// <summary>
	/// �x���z�̂����̐���ǉ�����
	/// </summary>
	/// <param name="count"></param>
	public static void AddToPaymentMoneyCount(int count = 1)
	{
		CurrentPaymentCount += count;
	}

	/// <summary>
	/// �������̂����̖�����ǉ�����
	/// </summary>
	/// <param name="count"></param>
	public static void AddToPocketMoneyCount(int count = 1)
	{
		CurrentPocketCount += count;
	}
}
