using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameController {
    public class GameTimeManager : MonoBehaviour {
        [Header("Components")]
        [SerializeField] TextMeshProUGUI timerText;

        [Header("Params")]
        [SerializeField] int startTime = 45;            // �J�n���̎���

        static float time;     // ����

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
            time = startTime;       // �J�n
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
            if (time > Time.deltaTime) {
                time -= Time.deltaTime;
            }

            // 0�b����������A0�b�ɂ���
            else {
                time = 0f;
                MainGameManager.isGameEnd = true;       // �Q�[���I��
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
        /// �^�C�}�[���Z
        /// </summary>
        public static void AddTimer(float addedTime)
        {
            time += addedTime;
        }

        /// <summary>
        /// �^�C�}�[���Z
        /// </summary>
        public static void RemoveTimer(float remmovedTime)
        {
            time -= remmovedTime;

            // 0�ȉ���������0�ɂ���
            if (time < 0) {
                time = 0;
            }
        }
    }
}