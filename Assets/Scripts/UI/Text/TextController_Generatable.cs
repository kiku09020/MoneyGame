using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController_Generatable : TextController_Base
{
	[SerializeField] bool destroyable;

    //--------------------------------------------------

	/// <summary>
	/// ������ɕ\������
	/// </summary>
    public void GenerateAndDispText(object value)
    {
		var obj = Instantiate(text, transform);

		obj.gameObject.SetActive(true);

		var message = SetMessage(value);

		DispText(obj, message, () => {

			// �I�����ɔj��
			if (destroyable) {
				Destroy(obj.gameObject);
			}
		});
	}

	/// <summary>
	/// ������ɕ\������(�����F�w��\)
	/// </summary>
	public void GenerateAndDispText(object value,Color color)
	{
		targetColor = color;

		var obj = Instantiate(text, transform);

		obj.gameObject.SetActive(true);

		var message = SetMessage(value);

		DispText(obj, message, () => {

			// �I�����ɔj��
			if (destroyable) {
				Destroy(obj.gameObject);
			}
		});
	}

	/// <summary>
	/// �e�L�X�g���b�Z�[�W�̎w��
	/// </summary>
	protected virtual string SetMessage(object value)
	{
		return $"{value.ToString()}";
	}
}
