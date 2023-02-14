using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController {
    public class GameStateMachine : StateMatchineBase<GameStateBase> {
        /* Properties */
        public static MainGameState MainState { get; private set; }
        public static TitleState TitleState { get; private set; }

		void Awake()
		{
			MainState = gameObject.AddComponent<MainGameState>();
			TitleState = gameObject.AddComponent<TitleState>();

			StateInit(MainState);
		}
	}
}