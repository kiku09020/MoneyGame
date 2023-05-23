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
        [SerializeField,Tooltip("�A�j���[�V�����R���|�[�l���g�̃��X�g")] 
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

		// Animation���擾
		protected DOTweenAnimation GetAnimation(string id)
        {
            foreach (var animation in animationList) {
                if(string.IsNullOrEmpty(animation.id)) {
                    throw new Exception("Animation��ID����ł��B");
                }

                if(animation.id == id) {
                    return animation;
                }
            }

            throw new Exception("�w�肳�ꂽID��Animation�͂���܂���B");
        }

		//--------------------------------------------------

		/// <summary>
		/// �O������̃A�j���[�V�����w��A�Đ�
		/// </summary>
		/// <param name="id"></param>
		public void PlayAnimation(string id)
        {
            var targetAnimation = GetAnimation(id);         // �A�j���[�V�����擾

            targetAnimation.DORestartAllById(id);           // �A�j���[�V�����Đ�
        }

        /// <summary>
        /// �o�^����Ă��邷�ׂẴA�j���[�V�������Đ�����
        /// </summary>
        public void PlayAllAnimations()
        {
            SetUIActivate(true);

            foreach (var animation in animationList) {
                animation.DORestart();              // �Đ�
            }
        }

        /// <summary>
        /// �ҋ@��ɃA�j���[�V�����Đ�
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