using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class WholeMoneyCalculator : MonoBehaviour
{
	[Header("Components")]
    [SerializeField] WholeMoneyInfo wholeMoneyInfo;
	[SerializeField] MoneyGenerator moneyGenerator;

	[Header("MoneyGroup")]
	[SerializeField] MoneyGroup paymentMG;

	[Header("Change")]
	[SerializeField] Transform targetTransform;

	//--------------------------------------------------

	/// <summary>
	/// x•¥‚¢‰Â”\‚©‚Ç‚¤‚©(x•¥Šz‚ª–Ú•WŠz‚æ‚è‚à‘å‚«‚¯‚ê‚Îx•¥‚¦‚é)
	/// </summary>
	public bool CanPay => (paymentMG.MoneyAmount >= wholeMoneyInfo.TargetMoneyAmount) ? true : false;

	//--------------------------------------------------

	public class changeMoneyUnit {
		public readonly WholeMoneyInfo.MoneyUnit moneyUnit;
		public readonly int count;

		public changeMoneyUnit(WholeMoneyInfo.MoneyUnit money, int count)
		{
			this.moneyUnit = money;
			this.count = count;
		}
	}

	//--------------------------------------------------


	/// <summary>
	/// x•¥‚¢
	/// </summary>
	public void Payment()
	{
		if (CanPay) {
			// ‚¨‚Â‚è¶¬‚µ‚ÄˆÚ“®
			moneyGenerator.GenerateAndMoveChange(GetCharge(), targetTransform);

			// –Ú•WŠztransform‚ÉˆÚ“®
			paymentMG.Mover.MoveToTargetTransform(targetTransform);


		}
	}

	/// <summary>
	/// x•¥‚¢‹àŠz‚ğèŒ³‚É–ß‚·
	/// </summary>
	public void Revert()
	{
		paymentMG.Mover.MoveToTarget(true, true, false);
	}

	//--------------------------------------------------

	// ‚¨‚Â‚è‚Ì–‡”‚Ìæ“¾
	List<changeMoneyUnit> GetCharge()
	{
		var changeMoneyList = new List<changeMoneyUnit>();		// ‚¨‚Â‚èƒŠƒXƒg
		var count = 0;      // ‚¨‚Â‚è‚Ì”

		// ‚¨‚Â‚è = x•¥Šz - –Ú•WŠz
		var change = paymentMG.MoneyAmount - wholeMoneyInfo.TargetMoneyAmount;

		// ‘å‚«‚¢•û‚©‚çƒ`ƒFƒbƒN
		for (int i = wholeMoneyInfo.MoneyUnitList.Count -1; i >= 0; i--) {
			var moneyUnit = wholeMoneyInfo.MoneyUnitList[i];

			// ‚¨‚Â‚è‚©‚çŠe‹àŠz•ªˆø‚¢‚½Œ‹‰Ê‚ª0‚æ‚è‘å‚«‚¢ê‡A”‚ğ’Ç‰Á
			while ((change - moneyUnit.Money.Data.Amount) >= 0) {
				change -= moneyUnit.Money.Data.Amount;
				count++;
			}

			// 0ˆÈ‰º‚É‚È‚Á‚½ê‡A‚¨‚Â‚è‚ÌƒŠƒXƒg‚É’Ç‰Á
			changeMoneyList.Add(new changeMoneyUnit(moneyUnit, count));     // ƒŠƒXƒg’Ç‰Á
			count = 0;                                                  // ƒJƒEƒ“ƒgƒŠƒZƒbƒg
		}

		return changeMoneyList;
	}

	// ƒ~ƒX”»’è
	bool CheckMiss()
	{
		var reached = false;    // x•¥Šz‚ª–Ú•WŠz‚É“’B‚µ‚½‚©‚Ç‚¤‚©

		var paidAmount = 0;     // x•¥Šz

		foreach (var mgUnit in paymentMG.MoneyGroupUnitList) {
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
