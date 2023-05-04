using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController_Generatable : TextController_Base
{
	[SerializeField] bool destroyable;

    //--------------------------------------------------

	/// <summary>
	/// 生成後に表示する
	/// </summary>
    public void GenerateAndDispText(object value)
    {
		var obj = Instantiate(text, transform);

		obj.gameObject.SetActive(true);

		var message = SetMessage(value);

		DispText(obj, message, () => {

			// 終了時に破棄
			if (destroyable) {
				Destroy(obj.gameObject);
			}
		});
	}

	/// <summary>
	/// 生成後に表示する(文字色指定可能)
	/// </summary>
	public void GenerateAndDispText(object value,Color color)
	{
		targetColor = color;

		var obj = Instantiate(text, transform);

		obj.gameObject.SetActive(true);

		var message = SetMessage(value);

		DispText(obj, message, () => {

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
