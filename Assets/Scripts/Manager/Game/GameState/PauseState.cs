using GameController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController {
    public class PauseState : GameStateBase {

		//--------------------------------------------------

		public override void OnEnter()
		{
			UIManager.ShowUIGroup<PauseUIGroup>();		// UIï\é¶

			TimeController.Stop();						// éûä‘í‚é~
			AudioController.PauseAllAudio();			// âπê∫í‚é~
		}

		public override void OnUpdate()
		{

		}

		public override void OnExit()
		{
			UIManager.ShowLastUIGroup();				// UIÇ‡Ç∆Ç…Ç‡Ç«Ç∑

			TimeController.ResetTimeScale();			// éûä‘í‚é~âèú
			AudioController.UnPauseAllAudio();			// âπê∫í‚é~âèú
		}
	}
}