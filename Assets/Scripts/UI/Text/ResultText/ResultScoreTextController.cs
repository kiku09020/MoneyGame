using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScoreTextController : ResultTextController
{

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
