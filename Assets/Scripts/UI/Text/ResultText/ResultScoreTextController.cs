using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScoreTextController : ResultTextController
{

	//--------------------------------------------------

	/// <summary>
	/// 現在の合計スコアを表示
	/// </summary>
	public override void DispText()
	{
		var message = ScoreManager.GetScoreString();

		DispText(message);
	}
}
