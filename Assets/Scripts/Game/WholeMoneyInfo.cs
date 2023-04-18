using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WholeMoneyInfo : MonoBehaviour
{
	// Amount

	/// <summary>
	/// –Ú•W‚Ìx•¥Šz
	/// </summary>
	public static int TargetPaymentAmount { get; private set; }

	/// <summary>
	/// Œ»İ‚Ìx•¥Šz
	/// </summary>
	public static int CurrentPaymentAmount { get; private set; }

	/// <summary>
	/// Œ»İ‚ÌŠ‹à
	/// </summary>
	public static int CurrentPocketAmount { get; private set; }

	// Count

	/// <summary>
	/// PaymentMG‚É‘¶İ‚·‚éMoney‚Ì”
	/// </summary>
	public static int CurrentPaymentCount { get; private set; }

	/// <summary>
	/// PlayerMG‚É‘¶İ‚·‚éMoney‚Ì”
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
	/// Œ»İ‚Ìx•¥Šz‚É‰ÁZ‚·‚é
	/// </summary>
	public static void AddToCurrentPaymentAmount(int amount)
	{
		CurrentPaymentAmount += amount;
	}

	/// <summary>
	/// Œ»İ‚ÌŠ‹à‚É‰ÁZ‚·‚é
	/// </summary>
	public static void AddToCurrentPocketAmount(int amount)
	{
		CurrentPocketAmount += amount;
	}

	//--------------------------------------------------
	/// <summary>
	/// x•¥Šz‚Ì‚¨‹à‚Ì”‚ğ’Ç‰Á‚·‚é
	/// </summary>
	/// <param name="count"></param>
	public static void AddToPaymentMoneyCount(int count = 1)
	{
		CurrentPaymentCount += count;
	}

	/// <summary>
	/// Š‹à‚Ì‚¨‹à‚Ì–‡”‚ğ’Ç‰Á‚·‚é
	/// </summary>
	/// <param name="count"></param>
	public static void AddToPocketMoneyCount(int count = 1)
	{
		CurrentPocketCount += count;
	}
}
