using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : UIController<Image>
{

	//--------------------------------------------------

	public override void SetUIActivate(bool activate)
	{
		uiObject.gameObject.SetActive(activate);
	}
}
