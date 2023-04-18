using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// �����̉��Z�E���Z�A�������̒ǉ��Ƃ�
/// </summary>
public class MoneyCalculater : MonoBehaviour
{
    [SerializeField] Money money;

    //--------------------------------------------------

    void Awake()
    {
        
    }

	/// <summary>
	/// �x���z�ɂ����̒l�i�����Z����B
	/// (�t���O�������Ă���΁A���������猸�Z����)
	/// </summary>
	/// <param name="removeFromPocket">���������猸�Z���邩�ǂ���</param>
	public void AddPaymentAmount(bool removeFromPocket = false)
    {
        WholeMoneyInfo.AddToCurrentPaymentAmount(money.Data.Value);     // �x���z�ɉ��Z

        if (removeFromPocket) {
            WholeMoneyInfo.AddToCurrentPocketAmount(-money.Data.Value);     // ���������猸�Z
        }
    }

    /// <summary>
    /// �������ɂ����̒l�i�����Z����B
    /// (�t���O�������Ă���΁A�x���z���猸�Z����)
    /// </summary>
    /// <param name="removeFromPayment">�x���z���猸�Z���邩�ǂ���</param>
    public void AddPocketAmount(bool removeFromPayment = false)
    {
        WholeMoneyInfo.AddToCurrentPocketAmount(money.Data.Value);      // �������ɉ��Z

        if (removeFromPayment) {
            WholeMoneyInfo.AddToCurrentPaymentAmount(-money.Data.Value);    // �x���z���猸�Z
        }
    }

	//--------------------------------------------------

	/// <summary>
	/// �x����̖�����ǉ�����
    /// (�t���O�������Ă���΁A�������̖��������炷)
	/// </summary>
	/// <param name="count">���₷����</param>
	public void AddPaymentCount(bool removeFromPocket = false, int count = 1)
	{
        WholeMoneyInfo.AddToPaymentMoneyCount(count);                   // �x����̖����ɒǉ�

        if (removeFromPocket) {
            WholeMoneyInfo.AddToPocketMoneyCount(-count);                   // �����������猸�炷
        }
	}

	/// <summary>
	/// �������̖�����ǉ�����
	/// (�t���O�������Ă���΁A�x����̖��������炷)
	/// </summary>
	/// <param name="count">���₷����</param>
	public void AddPocketCount(bool removeFromPayment = false, int count = 1)
	{
		WholeMoneyInfo.AddToPocketMoneyCount(count);                    // ���������ɒǉ�

        if (removeFromPayment) {
		    WholeMoneyInfo.AddToPaymentMoneyCount(-count);                  // �x����̖������猸�炷
        }
	}

	//--------------------------------------------------
}
