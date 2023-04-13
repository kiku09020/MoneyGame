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

    // CautionUI��\������
    public void ActivateCautionUI(string cautionName)
	{
        ActivateCaution(cautionName);
        cautionUIObject.SetActive(true);
	}

    // CautionUI���\���ɂ���
    public void DeactiveCautionUI()
    {
        nowCaution.flag = false;
        cautionUIObject.SetActive(false);
    }

	// ���X�g�ɓo�^���ꂽ�x���^�C�v�����w�肵�ėL����
	void ActivateCaution(string name)
    {
        foreach (var caution in cautions) {
            caution.flag = false;

            if (caution.Name == name) {
                nowCaution = caution;                   // ���݂̌x���ɂ���

                caution.flag = true;
                cautionText.text = caution.Text;        // TMP�Ƀe�L�X�g���e��K�p
            }
        }
    }

    public void YesButtonEvent()
    {
        nowCaution.OnClicked.Invoke();
    }
}
