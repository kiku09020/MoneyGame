using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController {
    using State;

    public class MainGameManager : MonoBehaviour {
        [SerializeField] GameStateMachine state;

        /// <summary>
        /// 操作可能フラグ
        /// </summary>
        public static bool isOperable;

        /// <summary>
        /// ゲーム終了フラグ
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
        /// ゲームをやり直す
        /// </summary>
        public void RestartGame()
        {
            state.NowState.OnExit();        // 現在の状態のStateの終了処理をする

            SceneControllerAsync.Instance.LoadNowScene();
        }

        /// <summary>
        /// ゲームを終了して、タイトルに戻る
        /// </summary>
        public void ExitGame()
        {
            state.NowState.OnExit();        // 現在の状態のStateの終了処理をする

            SceneControllerAsync.Instance.LoadPrevScene();
        }
    }
}