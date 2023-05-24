using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace GameController.UI.UIController {
	public class AddedTimeTextController : GeneratableTextController {

		[Header("Components")] 
		[SerializeField] TextMeshProUGUI totalTimerText;

		[Header("Actions")]
		[SerializeField] UnityEvent addedAction;

		public override void SetText<T>(T value)
		{
			addedAction.Invoke();		// 追加された時の処理

			SetTotalTimer();            // 合計タイムに反映

			var floatValue = Convert.ToSingle(value);				// floatに変換

			var signText = MathExtention.GetSignStr(floatValue);	// 符号文字列取得
			var absValue = Mathf.Abs(floatValue);					// 絶対値

			uiObject.text = $"{signText}{absValue}s";
		}

		// 合計タイマーのテキスト反映
		void SetTotalTimer()
		{
			totalTimerText.text = GameTimeManager.GetTimeText();
		}
	}
}