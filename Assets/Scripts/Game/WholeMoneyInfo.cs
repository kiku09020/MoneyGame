using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WholeMoneyInfo : MonoBehaviour
{
	// Amount

	/// <summary>
	/// 目標の支払額
	/// </summary>
	public static int TargetPaymentAmount { get; private set; }

	/// <summary>
	/// 現在の支払額
	/// </summary>
	public static int CurrentPaymentAmount { get; private set; }

	/// <summary>
	/// 現在の所持金
	/// </summary>
	public static int CurrentPocketAmount { get; private set; }

	// Count

	/// <summary>
	/// PaymentMGに存在するMoneyの数
	/// </summary>
	public static int CurrentPaymentCount { get; private set; }

	/// <summary>
	/// PlayerMGに存在するMoneyの数
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
	/// 現在の支払額に加算する
	/// </summary>
	public static void AddToCurrentPaymentAmount(int amount)
	{
		CurrentPaymentAmount += amount;
	}

	/// <summary>
	/// 現在の所持金に加算する
	/// </summary>
	public static void AddToCurrentPocketAmount(int amount)
	{
		CurrentPocketAmount += amount;
	}

	//--------------------------------------------------
	/// <summary>
	/// 支払額のお金の数を追加する
	/// </summary>
	/// <param name="count"></param>
	public static void AddToPaymentMoneyCount(int count = 1)
	{
		CurrentPaymentCount += count;
	}

	/// <summary>
	/// 所持金のお金の枚数を追加する
	/// </summary>
	/// <param name="count"></param>
	public static void AddToPocketMoneyCount(int count = 1)
	{
		CurrentPocketCount += count;
	}
}
