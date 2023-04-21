using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] TextMeshProUGUI timerText;

    [Header("Params")]
    [SerializeField] int startTime = 45;            // 開始時の時間

    float time;     // 時間

    /// <summary>
    /// 有効か
    /// </summary>
    public static bool Enabled { get; set; }

    /// <summary>
    /// タイマー終了したか
    /// </summary>
    public static bool Finished { get; private set; }

    //--------------------------------------------------

    void Awake()
    {
        Finished = false;
        Enabled = false;

        time = startTime;       // 開始
    }

    void FixedUpdate()
    {
        if (Enabled) {
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
            Finished = true;
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
