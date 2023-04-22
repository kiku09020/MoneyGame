using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController {
    public class GameEndState :GameStateBase
    {
		[SerializeField] float endDuration;

		//--------------------------------------------------

		public override void OnEnter()
		{
			print("EndState");
		}

		public override void OnUpdate()
		{

		}

		public override void OnExit()
		{

		}
	}
}