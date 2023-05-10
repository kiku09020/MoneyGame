using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController {
    using State;

    public class MainGameManager : MonoBehaviour {
        [SerializeField] GameStateMachine state;

        /// <summary>
        /// ����\�t���O
        /// </summary>
        public static bool isOperable;

        /// <summary>
        /// �Q�[���I���t���O
        /// </summary>
        public static bool isGameEnd;

        //--------------------------------------------------

        private void Start()
        {
            isGameEnd = false;
            isOperable = false;

            state.StateInit();
            BGM.Instance.Play(AudioNames.BGM_PALETTE, 0, 0.5f, 1);
        }

        void FixedUpdate()
        {
            state.StateUpdate();
        }

        /// <summary>
        /// �Q�[������蒼��
        /// </summary>
        public void RestartGame()
        {
            state.NowState.OnExit();        // ���݂̏�Ԃ�State�̏I������������

            SceneControllerAsync.Instance.LoadNowScene();
        }

        /// <summary>
        /// �Q�[�����I�����āA�^�C�g���ɖ߂�
        /// </summary>
        public void ExitGame()
        {
            state.NowState.OnExit();        // ���݂̏�Ԃ�State�̏I������������

            SceneControllerAsync.Instance.LoadPrevScene();
        }
    }
}