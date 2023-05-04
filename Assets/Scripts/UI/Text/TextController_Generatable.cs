using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController_Generatable : TextController_Base
{
	[SerializeField] bool destroyable;

    //--------------------------------------------------

    public void GenerateAndDispText(object value)
    {
		var obj = Instantiate(text, transform);

		obj.gameObject.SetActive(true);

		var message = SetMessage(value);

		DispText(obj, message, token, () => {

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
