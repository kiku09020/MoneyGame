using NatML.Sharing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.Button {
    public class ResultButtonsController : MonoBehaviour {

        //--------------------------------------------------

        // ���g���C�{�^��
        public void OnRetry()
        {
            SceneControllerAsync.Instance.LoadNowScene();
        }

        // �I���{�^��
        public void OnExit()
        {
            SceneControllerAsync.Instance.LoadPrevScene();
        }

        // ���L�{�^��
        public async void OnShare()
        {
            var payLoad = new SharePayload();

            payLoad.AddText("�����[��");

            await payLoad.Share();
        }

    }
}