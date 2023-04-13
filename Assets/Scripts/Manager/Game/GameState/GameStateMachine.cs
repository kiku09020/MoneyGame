using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController {
    public class GameStateMachine : StateMatchineBase<GameStateBase> {
		[SerializeField] string initStateName;

		void Start()
		{
			StateInit(initStateName);
		}
	}
}