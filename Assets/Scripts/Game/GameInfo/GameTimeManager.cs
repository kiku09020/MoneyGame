using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameController {
    public class GameTimeManager : MonoBehaviour {
        [Header("Components")]
        [SerializeField] TextMeshProUGUI timerText;

        [Header("Params")]
        [SerializeField] int startTime = 45;                // �J�n���̎���

        public static float TotalTime { get; private set; } // ����

        static bool infinityTimeToggle;

        /// <summary>
        /// ���Ԑ������Ȃ����g�O��
        /// </summary>
        public static bool InfinityTimeToggle => infinityTimeToggle = !infinityTimeToggle;

        // UnityButton�p
        public void InfinityTimeToggle_Button()
        {
            infinityTimeToggle = !infinityTimeToggle;
        }

        //--------------------------------------------------

        void Awake()
        {
            TotalTime = startTime;       // �J�n
        }

        void FixedUpdate()
        {
            // ����\���Ƀ^�C�}�[���X�V
            if (MainGameManager.isOperable && !infinityTimeToggle) {
                Timer();
            }
        }

        void Timer()
        {
            // 0�b���傫����΁A���Ԃ����炷
            if (TotalTime > Time.deltaTime) {
                TotalTime -= Time.deltaTime;
            }

            // 0�b����������A0�b�ɂ���
            else {
                TotalTime = 0f;
                MainGameManager.isGameEnd = true;       // �Q�[���I��
            }

            timerText.text = GetTimeText();      // �e�L�X�g�\��
        }

		//--------------------------------------------------

		// ���Ԃ̕��A�b�A�~���b��z��Ƃ��Ď擾
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
        /// �^�C�}�[���Z
        /// </summary>
        public static void AddTimer(float addedTime)
        {
            TotalTime += addedTime;
        }

        /// <summary>
        /// �^�C�}�[���Z
        /// </summary>
        public static void RemoveTimer(float remmovedTime)
        {
            TotalTime -= remmovedTime;

            // 0�ȉ���������0�ɂ���
            if (TotalTime < 0) {
                TotalTime = 0;
            }
        }
    }
}