using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class CautionUIController : MonoBehaviour
{
    [SerializeField] GameObject cautionUIObject;
    [SerializeField] TextMeshProUGUI cautionText;

    [Header("Caution")]
    [SerializeField] List<Caution> cautions = new List<Caution>();

    [Serializable] class Caution
    {
        [SerializeField] string name;

        [Header("Params")]
        [HideInInspector] public bool flag;
        [SerializeField] string text;
        [SerializeField] UnityEvent onClicked;

        public string Name => name;
        public string Text => text;

        public UnityEvent OnClicked => onClicked;
    }

    Caution nowCaution;

    //--------------------------------------------------

    void Awake()
    {
        cautionUIObject.SetActive(false);
    }

    // CautionUIを表示する
    public void ActivateCautionUI(string cautionName)
	{
        ActivateCaution(cautionName);
        cautionUIObject.SetActive(true);
	}

    // CautionUIを非表示にする
    public void DeactiveCautionUI()
    {
        nowCaution.flag = false;
        cautionUIObject.SetActive(false);
    }

	// リストに登録された警告タイプ名を指定して有効化
	void ActivateCaution(string name)
    {
        foreach (var caution in cautions) {
            caution.flag = false;

            if (caution.Name == name) {
                nowCaution = caution;                   // 現在の警告にする

                caution.flag = true;
                cautionText.text = caution.Text;        // TMPにテキスト内容を適用
            }
        }
    }

    public void YesButtonEvent()
    {
        nowCaution.OnClicked.Invoke();
    }
}
