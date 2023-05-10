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
			UIGroupManager.ShowUIGroup<PauseUIGroup>();		// UI�\��

			TimeController.Stop();						// ���Ԓ�~
			AudioController.PauseAllAudio();			// ������~
		}

		public override void OnUpdate()
		{

		}

		public override void OnExit()
		{
			UIGroupManager.ShowLastUIGroup();				// UI���Ƃɂ��ǂ�

			TimeController.ResetTimeScale();			// ���Ԓ�~����
			AudioController.UnPauseAllAudio();			// ������~����
		}
	}
}