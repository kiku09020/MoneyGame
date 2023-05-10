using GameController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.State {

	using UI.UIGroup;

    public class PauseState : GameStateBase {

		//--------------------------------------------------

		public override void OnEnter()
		{
			UIGroupManager.ShowUIGroup<PauseUIGroup>();		// UIï\é¶

			TimeController.Stop();						// éûä‘í‚é~
			AudioController.PauseAllAudio();			// âπê∫í‚é~
		}

		public override void OnUpdate()
		{

		}

		public override void OnExit()
		{
			UIGroupManager.ShowLastUIGroup();				// UIÇ‡Ç∆Ç…Ç‡Ç«Ç∑

			TimeController.ResetTimeScale();			// éûä‘í‚é~âèú
			AudioController.UnPauseAllAudio();			// âπê∫í‚é~âèú
		}
	}
}