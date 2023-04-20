using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// x•¥‚¢‚Ì•]‰¿‚ğ‚·‚éƒNƒ‰ƒX
/// </summary>
/// 
public class MoneyEvaluation : MonoBehaviour
{
    [SerializeField] WholeMoneyInfo wholeMoneyInfo;

	/// <summary>
	/// Š–‡”‚ªÅ‘å”‚æ‚è‚à‘½‚¢‚©
	/// </summary>
	public bool IsOverPocketMoney => (wholeMoneyInfo.PocketMG.MoneyAmount > wholeMoneyInfo.PocketMoneyMaxCount) ? true : false;

    //--------------------------------------------------

	/// <summary>
	/// ƒ~ƒX”»’è
	/// </summary>
	public bool CheckMiss()
	{
		var reached = false;    // x•¥Šz‚ª–Ú•WŠz‚É“’B‚µ‚½‚©‚Ç‚¤‚©

		var paidAmount = 0;     // x•¥Šz

		foreach (var mgUnit in wholeMoneyInfo.PaymentMG.MoneyGroupUnitList) {
			foreach (var money in mgUnit.MoneyList) {

				// “’B‚µ‚Ä‚¢‚È‚¯‚ê‚Î‰ÁZ
				if (!reached) {
					paidAmount += money.Data.Amount;        // x•¥Šz‚É‰ÁZ

					// –Ú•WŠz‚æ‚è‚àx•¥Šz‚ª‘½‚­‚È‚Á‚½‚çA“’Bƒtƒ‰ƒO—§‚Ä‚é
					if (wholeMoneyInfo.TargetMoneyAmount < paidAmount) {
						reached = true;
					}
				}

				// “’B‚µ‚½‚Ì‚ÉŒJ‚è•Ô‚µ‚ª‘±‚­ê‡A—]•ª‚Éx•¥‚Á‚½‚½‚ßAƒ~ƒX”»’è‚Æ‚·‚é
				else {
					return true;
				}
			}
		}

		return false;
	}
}
