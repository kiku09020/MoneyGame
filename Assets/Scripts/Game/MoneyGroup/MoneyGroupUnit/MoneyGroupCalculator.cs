using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyGroupCalculator : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] MoneyGroup moneyGroup;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI text;



    //--------------------------------------------------

    void Awake()
    {
        
    }

	private void FixedUpdate()
	{
        text.text = moneyGroup.MoneyAmount.ToString();
	}
}
