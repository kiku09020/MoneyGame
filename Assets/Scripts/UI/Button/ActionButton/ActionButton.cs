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
        [SerializeField,Tooltip("クリックされたときのサブアクション")] 
        protected UnityEvent clickedSubAction;

        [SerializeField,Tooltip("クリックされなかったときのサブアクション")] 
        protected UnityEvent cantClickSubAction;

		/// <summary>
		/// クリック可能条件
		/// </summary>
		protected abstract bool Clickable { get; }       

        //--------------------------------------------------

        private void FixedUpdate()
        {
            // 操作可能フラグに合わせてボタンの操作を制御
            if (MainGameManager.isOperable) {
                button.interactable = true;
            }

            else {
                button.interactable = false;
            }
        }

		//--------------------------------------------------

        // クリック時の処理
        public void OnClicked()
        {
            // 操作可能か確認
            if(MainGameManager.isOperable) {

                // クリック可能かどうか
                if(Clickable) {
                    CommonClickedActions();     // 共通処理

                    ClickedAction();            // クリック時の処理
                }

                else {
                    CommonCantClickAction();    // 共通処理

					CantClickAction();          // クリック不可時の処理
                }
            }
        }

		//--------------------------------------------------
        // クリック可能時の共通処理
        void CommonClickedActions()
        {
            clickedSubAction.Invoke();                              // サブアクション実行
                                                                    
            SE.Instance.Play(AudioNames.SE_BUTTON_CLICK);           // 音声再生
        }

        // クリック不可時の共通処理
        void CommonCantClickAction()
        {
            cantClickSubAction.Invoke();                            // サブアクション実行
                                                                    
			SE.Instance.Play(AudioNames.SE_BUTTON_CANCEL);          // 音声再生

		}

		//--------------------------------------------------

		/// <summary>
		/// クリックされたときの処理
		/// </summary>
		abstract protected void ClickedAction();

        /// <summary>
        /// アクションを実行できない時の処理
        /// </summary>
        abstract protected void CantClickAction();

		//--------------------------------------------------


	}
}