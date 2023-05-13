using Game.Money.MoneyManager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameController.UI.TextController {
	public class EvaluateTextController : TextController_Generatable {

		[Header("Components")]
		[SerializeField] MoneyEvaluator evaluator;
		TextMeshProUGUI miniText;

		private void Awake()
		{
			miniText = text.transform.GetChild(0)?.GetComponent<TextMeshProUGUI>();
		}

		protected override string SetMessage(object value)
		{
			miniText.gameObject.SetActive(false);		// 一旦非表示

			// パーフェクトだったら表示(仮)
			if (evaluator.IsPerfect) {
				miniText.gameObject.SetActive(true);
			}

			return value.ToString();
		}
	}
}