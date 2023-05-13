using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameController {
    public class GameTimeManager : MonoBehaviour {
        [Header("Components")]
        [SerializeField] TextMeshProUGUI timerText;

        [Header("Params")]
        [SerializeField] int startTime = 45;                // 開始時の時間

        public static float TotalTime { get; private set; } // 時間

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
            TotalTime = startTime;       // 開始
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
            if (TotalTime > Time.deltaTime) {
                TotalTime -= Time.deltaTime;
            }

            // 0秒をすぎたら、0秒にする
            else {
                TotalTime = 0f;
                MainGameManager.isGameEnd = true;       // ゲーム終了
            }

            timerText.text = GetTimeText();      // テキスト表示
        }

		//--------------------------------------------------

		// 時間の分、秒、ミリ秒を配列として取得
		static int[] GetTimeUnits()
        {
            var unitsArray = new int[3];

            unitsArray[0] = Mathf.FloorToInt(TotalTime / 60);
            unitsArray[1] = Mathf.FloorToInt(TotalTime % 60);
            unitsArray[2] = Mathf.FloorToInt((TotalTime - Mathf.Floor(TotalTime)) * 100);

            return unitsArray;
        }

        public static string GetTimeText(int min,int sec,int milSec)
        {
            return string.Format("{0:00}:{1:00}:{2:00}", min, sec, milSec);
		}

        public static string GetTimeText()
        {
            var units = GetTimeUnits();

            return GetTimeText(units[0], units[1], units[2]);
        }

        //--------------------------------------------------



        /// <summary>
        /// タイマー加算
        /// </summary>
        public static void AddTimer(float addedTime)
        {
            TotalTime += addedTime;
        }

        /// <summary>
        /// タイマー減算
        /// </summary>
        public static void RemoveTimer(float remmovedTime)
        {
            TotalTime -= remmovedTime;

            // 0以下だったら0にする
            if (TotalTime < 0) {
                TotalTime = 0;
            }
        }
    }
}