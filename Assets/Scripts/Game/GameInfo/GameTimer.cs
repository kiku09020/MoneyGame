using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] TextMeshProUGUI timerText;

    [Header("Params")]
    [SerializeField] int startTime = 45;            // �J�n���̎���

    float time;     // ����

    /// <summary>
    /// �L����
    /// </summary>
    public static bool Enabled { get; set; }

    //--------------------------------------------------

    void Awake()
    {
        Enabled = false;

        time = startTime;       // �J�n
    }

    void FixedUpdate()
    {
        if (Enabled) {
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

    void Disp(int min,int sec,int milSec)
    {
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, milSec);
	}
}
