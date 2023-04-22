using DG.Tweening;
using GameController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController {
    public class MainState : GameStateBase {
		[SerializeField] RectTransform gameInfoUI;

		//--------------------------------------------------

		private void Awake()
		{
			gameInfoUI.localScale = Vector3.zero;
		}

		public override void OnEnter()
		{
			gameInfoUI.DOScale(1, .5f);
		}

		public override void OnUpdate()
		{

		}

		public override void OnExit()
		{

		}
	}
}