using NatML.Sharing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.Button {
    public class ResultButtonsController : MonoBehaviour {

        //--------------------------------------------------

        // リトライボタン
        public void OnRetry()
        {
            SceneControllerAsync.Instance.LoadNowScene();
        }

        // 終了ボタン
        public void OnExit()
        {
            SceneControllerAsync.Instance.LoadPrevScene();
        }

        // 共有ボタン
        public async void OnShare()
        {
            var payLoad = new SharePayload();

            payLoad.AddText("いえーい");

            await payLoad.Share();
        }

    }
}