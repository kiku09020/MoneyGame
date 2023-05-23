using Cysharp.Threading.Tasks;
using GameController.UI.TextController;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Money.MoneyManager.Evaluator {
	/// <summary>
	/// •]‰¿Šî’êƒNƒ‰ƒX
	/// </summary>
	public abstract class Evaluator_Base : MonoBehaviour {
		[Header("Text")]
		[SerializeField, Tooltip("ƒeƒLƒXƒg")] protected TextController textController;

		[Header("Components")]
		[HideInInspector] public WholeMoneyInfo moneyInfo;

		//--------------------------------------------------

		/// <summary>
		/// •]‰¿Œ‹‰Ê‚ÉŠî‚Ã‚¢‚½ˆ—
		/// </summary>
		public event Action BasedEvalAction;

		/// <summary>
		/// •]‰¿‚ÌğŒ
		/// </summary>
		protected abstract bool Condition(WholeMoneyInfo moneyInfo);

		/// <summary>
		/// •]‰¿‚Ìˆ—
		/// </summary>
		protected abstract void EvaluatedAction();

		/// <summary>
		/// •]‰¿
		/// </summary>
		/// <returns>•]‰¿‚³‚ê‚½‚©‚Ç‚¤‚©</returns>
		public bool Evaluate(WholeMoneyInfo moneyInfo)
		{
			if (Condition(moneyInfo)) {
				EvaluatedAction();				// •]‰¿‚³‚ê‚½‚Æ‚«‚Ìˆ—

				BasedEvalAction?.Invoke();		// •]‰¿‚ÉŠî‚Ã‚¢‚½ˆ—‚ğÀs

				return true;
			}
			

			return false;
		}
	}
}