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

		public override void SetText<T>(T value)
		{
			SetTotalTimer();            // ���v�^�C���ɔ��f

			var floatValue = Convert.ToSingle(value);				// float�ɕϊ�

			var signText = MathExtention.GetSignStr(floatValue);	// ����������擾
			var absValue = Mathf.Abs(floatValue);					// ��Βl

			uiObject.text = $"{signText}{absValue}s";
		}

		// ���v�^�C�}�[�̃e�L�X�g���f
		void SetTotalTimer()
		{
			totalTimerText.text = GameTimeManager.GetTimeText();
		}
	}
}