using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WholeMoneyInfo : MonoBehaviour
{
	[SerializeField,Tooltip("�ڕW�̎x���z�̃e�L�X�g")] TextMeshProUGUI targetPaymentAmountText;
	[SerializeField,Tooltip("���݂̎x���z�̃e�L�X�g")] TextMeshProUGUI currentPaymentAmountText;

	[SerializeField,Tooltip("���݂̏��������� / �ő及��������")] TextMeshProUGUI currentCountText;
}
