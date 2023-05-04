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

			// 終了時に破棄
			if (destroyable) {
				Destroy(obj.gameObject);
			}
		});
	}

	/// <summary>
	/// テキストメッセージの指定
	/// </summary>
	protected virtual string SetMessage(object value)
	{
		return $"{value.ToString()}";
	}
}
