using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

namespace GameController.UI.TextController {
    public class TextController_Base : UIController<TextMeshProUGUI> {

        [Header("UI")]
        [SerializeField] protected TextMeshProUGUI text;

        [Header("Animations")]
        [SerializeField,Tooltip("アニメーションコンポーネントのリスト")] 
        protected List<DOTweenAnimation> animationList = new List<DOTweenAnimation>();

        //--------------------------------------------------

        CancellationToken token;

		void Awake()
		{
            token = this.GetCancellationTokenOnDestroy();

            SetUIActivate(false);
		}

		public override void SetUIActivate(bool activate)
		{
            uiObject.gameObject.SetActive(activate);
		}

		//--------------------------------------------------

		// Animationを取得
		protected DOTweenAnimation GetAnimation(string id)
        {
            foreach (var animation in animationList) {
                if(string.IsNullOrEmpty(animation.id)) {
                    throw new Exception("AnimationのIDが空です。");
                }

                if(animation.id == id) {
                    return animation;
                }
            }

            throw new Exception("指定されたIDのAnimationはありません。");
        }

		//--------------------------------------------------

		/// <summary>
		/// 外部からのアニメーション指定、再生
		/// </summary>
		/// <param name="id"></param>
		public void PlayAnimation(string id)
        {
            var targetAnimation = GetAnimation(id);         // アニメーション取得

            targetAnimation.DORestartAllById(id);           // アニメーション再生
        }

        /// <summary>
        /// 登録されているすべてのアニメーションを再生する
        /// </summary>
        public void PlayAllAnimations()
        {
            SetUIActivate(true);

            foreach (var animation in animationList) {
                animation.DORestart();              // 再生
            }
        }

        /// <summary>
        /// 待機後にアニメーション再生
        /// </summary>
        public async void PlayAnimationsWithWait(float waitDuration)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(waitDuration),cancellationToken:token);

            SetUIActivate(true);

            foreach (var animation in animationList) {
                animation.DORestart();
            }
        }

		//--------------------------------------------------
	}
}