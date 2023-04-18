using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WholeMoneyInfo : MonoBehaviour
{
	[SerializeField,Tooltip("目標の支払額のテキスト")] TextMeshProUGUI targetPaymentAmountText;
	[SerializeField,Tooltip("現在の支払額のテキスト")] TextMeshProUGUI currentPaymentAmountText;

	[SerializeField,Tooltip("現在の所持金枚数 / 最大所持金枚数")] TextMeshProUGUI currentCountText;
}
