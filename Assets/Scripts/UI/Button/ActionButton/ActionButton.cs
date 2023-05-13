using Game.Money.MoneyManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameController.UI.Button {
    public abstract class ActionButton : MonoBehaviour {
        [SerializeField] UnityEngine.UI.Button button;

        [Header("Components")]
		[SerializeField] protected WholeMoneyInfo moneyInfo;
		[SerializeField] protected WholeMoneyCalculator calculator;

        [Header("Actions")]
        [SerializeField,Tooltip("�N���b�N���ꂽ�Ƃ��̃T�u�A�N�V����")] 
        protected UnityEvent clickedSubAction;

        [SerializeField,Tooltip("�N���b�N����Ȃ������Ƃ��̃T�u�A�N�V����")] 
        protected UnityEvent cantClickSubAction;

		/// <summary>
		/// �N���b�N�\����
		/// </summary>
		protected abstract bool Clickable { get; }       

        //--------------------------------------------------

        private void FixedUpdate()
        {
            // ����\�t���O�ɍ��킹�ă{�^���̑���𐧌�
            if (MainGameManager.isOperable) {
                button.interactable = true;
            }

            else {
                button.interactable = false;
            }
        }

		//--------------------------------------------------

        // �N���b�N���̏���
        public void OnClicked()
        {
            // ����\���m�F
            if(MainGameManager.isOperable) {

                // �N���b�N�\���ǂ���
                if(Clickable) {
                    CommonClickedActions();     // ���ʏ���

                    ClickedAction();            // �N���b�N���̏���
                }

                else {
                    CommonCantClickAction();    // ���ʏ���

					CantClickAction();          // �N���b�N�s���̏���
                }
            }
        }

		//--------------------------------------------------
        // �N���b�N�\���̋��ʏ���
        void CommonClickedActions()
        {
            clickedSubAction.Invoke();                              // �T�u�A�N�V�������s
                                                                    
            SE.Instance.Play(AudioNames.SE_BUTTON_CLICK);           // �����Đ�
        }

        // �N���b�N�s���̋��ʏ���
        void CommonCantClickAction()
        {
            cantClickSubAction.Invoke();                            // �T�u�A�N�V�������s
                                                                    
			SE.Instance.Play(AudioNames.SE_BUTTON_CANCEL);          // �����Đ�

		}

		//--------------------------------------------------

		/// <summary>
		/// �N���b�N���ꂽ�Ƃ��̏���
		/// </summary>
		abstract protected void ClickedAction();

        /// <summary>
        /// �A�N�V���������s�ł��Ȃ����̏���
        /// </summary>
        abstract protected void CantClickAction();

		//--------------------------------------------------


	}
}