using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameController.UI.UIController {
	public class ImageController : UIController<Image,UIAnimData> {

		//--------------------------------------------------

		public override void SetUIActivate(bool activate)
		{
			uiObject.gameObject.SetActive(activate);
		}
	}
}