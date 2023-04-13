using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController {
    public class GameStateMachine : StateMatchineBase<GameStateBase> {
		void Start()
		{
			StateInit("MainState");
		}
	}
}