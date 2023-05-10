using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.TextController {
	public class ResultScoreTextController : ResultTextController {

		//--------------------------------------------------

		/// <summary>
		/// ���݂̍��v�X�R�A��\��
		/// </summary>
		public override void DispText()
		{
			var message = ScoreManager.GetScoreString();

			DispText(message);
		}
	}
}