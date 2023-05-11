using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameController {
    public class GameTimeManager : MonoBehaviour {
        [Header("Components")]
        [SerializeField] TextMeshProUGUI timerText;

        [Header("Params")]
        [SerializeField] int startTime = 45;            // 開始時の時間

        static float time;     // 時間

        static bool infinityTimeToggle;

        /// <summary>
        /// 時間制限をなくすトグル
        /// </summary>
        public static bool InfinityTimeToggle => infinityTimeToggle = !infinityTimeToggle;

        // UnityButton用
        public void InfinityTimeToggle_Button()
        {
            infinityTimeToggle = !infinityTimeToggle;
        }

        //--------------------------------------------------

        void Awake()
        {
            time = startTime;       // 開始
        }

        void FixedUpdate()
        {
            // 操作可能時にタイマーを更新
            if (MainGameManager.isOperable && !infinityTimeToggle) {
                Timer();
            }
        }

        void Timer()
        {
            // 0秒より大きければ、時間を減らす
            if (time > Time.deltaTime) {
                time -= Time.deltaTime;
            }

            // 0秒をすぎたら、0秒にする
            else {
                time = 0f;
                MainGameManager.isGameEnd = true;       // ゲーム終了
            }

            var min = Mathf.FloorToInt(time / 60);
            var sec = Mathf.FloorToInt(time % 60);
            var milSec = Mathf.FloorToInt((time - Mathf.Floor(time)) * 100);

            Disp(min, sec, milSec);
        }

        void Disp(int min, int sec, int milSec)
        {
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, milSec);
        }

        //--------------------------------------------------

        /// <summary>
        /// タイマー加算
        /// </summary>
        public static void AddTimer(float addedTime)
        {
            time += addedTime;
        }

        /// <summary>
        /// タイマー減算
        /// </summary>
        public static void RemoveTimer(float remmovedTime)
        {
            time -= remmovedTime;

            // 0以下だったら0にする
            if (time < 0) {
                time = 0;
            }
        }
    }
}