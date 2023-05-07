using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController {
    public class ResultState : GameStateBase {

		//--------------------------------------------------

		public override void OnEnter()
		{
			UIManager.ShowUIGroup<ResultUIGroup>();
		}

		public override void OnUpdate()
		{

		}

		public override void OnExit()
		{

		}
	}
}