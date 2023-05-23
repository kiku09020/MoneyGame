using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace GameController.UI.TextController {
	public class AddedTimeTextController : GeneratableTextController {

		[Header("Components")] 
		[SerializeField] TextMeshProUGUI totalTimerText;

		[Header("Actions")]
		[SerializeField] UnityEvent addedAction;

		public override void SetTextMessage(float value)
		{
			addedAction.Invoke();		// �ǉ����ꂽ���̏���

			SetTotalTimer();			// ���v�^�C���ɔ��f

			// ��������
			var signText = ((float)value > 0) ? "+" : "-";

			var absValue = Mathf.Abs((float)value);

			uiObject.text = $"{signText}{absValue}s";
		}

		// ���v�^�C�}�[�̃e�L�X�g���f
		void SetTotalTimer()
		{
			totalTimerText.text = GameTimeManager.GetTimeText();
		}
	}
}