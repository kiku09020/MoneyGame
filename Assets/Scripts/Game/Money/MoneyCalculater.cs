using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// お金の加算・減算、所持金の追加とか
/// </summary>
public class MoneyCalculater : MonoBehaviour
{
    [SerializeField] Money money;

    //--------------------------------------------------

    void Awake()
    {
        
    }

	/// <summary>
	/// 支払額にお金の値段分加算する。
	/// (フラグが立っていれば、所持金から減算する)
	/// </summary>
	/// <param name="removeFromPocket">所持金から減算するかどうか</param>
	public void AddPaymentAmount(bool removeFromPocket = false)
    {
        WholeMoneyInfo.AddToCurrentPaymentAmount(money.Data.Value);     // 支払額に加算

        if (removeFromPocket) {
            WholeMoneyInfo.AddToCurrentPocketAmount(-money.Data.Value);     // 所持金から減算
        }
    }

    /// <summary>
    /// 所持金にお金の値段分加算する。
    /// (フラグが立っていれば、支払額から減算する)
    /// </summary>
    /// <param name="removeFromPayment">支払額から減算するかどうか</param>
    public void AddPocketAmount(bool removeFromPayment = false)
    {
        WholeMoneyInfo.AddToCurrentPocketAmount(money.Data.Value);      // 所持金に加算

        if (removeFromPayment) {
            WholeMoneyInfo.AddToCurrentPaymentAmount(-money.Data.Value);    // 支払額から減算
        }
    }

	//--------------------------------------------------

	/// <summary>
	/// 支払先の枚数を追加する
    /// (フラグが立っていれば、所持金の枚数を減らす)
	/// </summary>
	/// <param name="count">増やす枚数</param>
	public void AddPaymentCount(bool removeFromPocket = false, int count = 1)
	{
        WholeMoneyInfo.AddToPaymentMoneyCount(count);                   // 支払先の枚数に追加

        if (removeFromPocket) {
            WholeMoneyInfo.AddToPocketMoneyCount(-count);                   // 所持枚数から減らす
        }
	}

	/// <summary>
	/// 所持金の枚数を追加する
	/// (フラグが立っていれば、支払先の枚数を減らす)
	/// </summary>
	/// <param name="count">増やす枚数</param>
	public void AddPocketCount(bool removeFromPayment = false, int count = 1)
	{
		WholeMoneyInfo.AddToPocketMoneyCount(count);                    // 所持枚数に追加

        if (removeFromPayment) {
		    WholeMoneyInfo.AddToPaymentMoneyCount(-count);                  // 支払先の枚数から減らす
        }
	}

	//--------------------------------------------------
}
