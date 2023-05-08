using GameController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController {
    public class PauseState : GameStateBase {

		//--------------------------------------------------

		public override void OnEnter()
		{
			UIManager.ShowUIGroup<PauseUIGroup>();		// UI表示

			TimeController.Stop();						// 時間停止
			AudioController.PauseAllAudio();			// 音声停止
		}

		public override void OnUpdate()
		{

		}

		public override void OnExit()
		{
			UIManager.ShowLastUIGroup();				// UIもとにもどす

			TimeController.ResetTimeScale();			// 時間停止解除
			AudioController.UnPauseAllAudio();			// 音声停止解除
		}
	}
}