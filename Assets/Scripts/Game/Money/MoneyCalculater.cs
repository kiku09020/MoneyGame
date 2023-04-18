using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// ‚¨‹à‚Ì‰ÁZEŒ¸ZAŠ‹à‚Ì’Ç‰Á‚Æ‚©
/// </summary>
public class MoneyCalculater : MonoBehaviour
{
    [SerializeField] Money money;

    //--------------------------------------------------

    void Awake()
    {
        
    }

	/// <summary>
	/// x•¥Šz‚É‚¨‹à‚Ì’l’i•ª‰ÁZ‚·‚éB
	/// (ƒtƒ‰ƒO‚ª—§‚Á‚Ä‚¢‚ê‚ÎAŠ‹à‚©‚çŒ¸Z‚·‚é)
	/// </summary>
	/// <param name="removeFromPocket">Š‹à‚©‚çŒ¸Z‚·‚é‚©‚Ç‚¤‚©</param>
	public void AddPaymentAmount(bool removeFromPocket = false)
    {
        WholeMoneyInfo.AddToCurrentPaymentAmount(money.Data.Value);     // x•¥Šz‚É‰ÁZ

        if (removeFromPocket) {
            WholeMoneyInfo.AddToCurrentPocketAmount(-money.Data.Value);     // Š‹à‚©‚çŒ¸Z
        }
    }

    /// <summary>
    /// Š‹à‚É‚¨‹à‚Ì’l’i•ª‰ÁZ‚·‚éB
    /// (ƒtƒ‰ƒO‚ª—§‚Á‚Ä‚¢‚ê‚ÎAx•¥Šz‚©‚çŒ¸Z‚·‚é)
    /// </summary>
    /// <param name="removeFromPayment">x•¥Šz‚©‚çŒ¸Z‚·‚é‚©‚Ç‚¤‚©</param>
    public void AddPocketAmount(bool removeFromPayment = false)
    {
        WholeMoneyInfo.AddToCurrentPocketAmount(money.Data.Value);      // Š‹à‚É‰ÁZ

        if (removeFromPayment) {
            WholeMoneyInfo.AddToCurrentPaymentAmount(-money.Data.Value);    // x•¥Šz‚©‚çŒ¸Z
        }
    }

	//--------------------------------------------------

	/// <summary>
	/// x•¥æ‚Ì–‡”‚ğ’Ç‰Á‚·‚é
    /// (ƒtƒ‰ƒO‚ª—§‚Á‚Ä‚¢‚ê‚ÎAŠ‹à‚Ì–‡”‚ğŒ¸‚ç‚·)
	/// </summary>
	/// <param name="count">‘‚â‚·–‡”</param>
	public void AddPaymentCount(bool removeFromPocket = false, int count = 1)
	{
        WholeMoneyInfo.AddToPaymentMoneyCount(count);                   // x•¥æ‚Ì–‡”‚É’Ç‰Á

        if (removeFromPocket) {
            WholeMoneyInfo.AddToPocketMoneyCount(-count);                   // Š–‡”‚©‚çŒ¸‚ç‚·
        }
	}

	/// <summary>
	/// Š‹à‚Ì–‡”‚ğ’Ç‰Á‚·‚é
	/// (ƒtƒ‰ƒO‚ª—§‚Á‚Ä‚¢‚ê‚ÎAx•¥æ‚Ì–‡”‚ğŒ¸‚ç‚·)
	/// </summary>
	/// <param name="count">‘‚â‚·–‡”</param>
	public void AddPocketCount(bool removeFromPayment = false, int count = 1)
	{
		WholeMoneyInfo.AddToPocketMoneyCount(count);                    // Š–‡”‚É’Ç‰Á

        if (removeFromPayment) {
		    WholeMoneyInfo.AddToPaymentMoneyCount(-count);                  // x•¥æ‚Ì–‡”‚©‚çŒ¸‚ç‚·
        }
	}

	//--------------------------------------------------
}
