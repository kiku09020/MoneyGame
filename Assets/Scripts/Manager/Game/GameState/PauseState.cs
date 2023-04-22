using GameController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController {
    public class PauseState : GameStateBase {

		//--------------------------------------------------

		public override void OnEnter()
		{
			UIManager.ShowUIGroup<PauseUIGroup>();
		}

		public override void OnUpdate()
		{

		}

		public override void OnExit()
		{
			UIManager.ShowLastUIGroup();
		}
	}
}