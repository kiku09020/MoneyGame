using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace GameController.UI.TextController {
	public class AddedTimeTextController : TextController_Generatable {

		[Header("Components")] 
		[SerializeField] TextMeshProUGUI totalTimerText;

		[Header("Actions")]
		[SerializeField] UnityEvent addedAction;

		protected override string SetMessage(object value)
		{
			addedAction.Invoke();		// 追加された時の処理

			SetTotalTimer();			// 合計タイムに反映

			// 符号判定
			var signText = ((float)value > 0) ? "+" : "-";

			var absValue = Mathf.Abs((float)value);

			return $"{signText}{absValue}s";
		}

		// 合計タイマーのテキスト反映
		void SetTotalTimer()
		{
			totalTimerText.text = GameTimeManager.GetTimeText();
		}
	}
}