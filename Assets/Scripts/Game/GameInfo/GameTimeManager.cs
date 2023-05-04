using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] TextMeshProUGUI timerText;

    [Header("Params")]
    [SerializeField] int startTime = 45;            // 開始時の時間

    static float time;     // 時間

    /// <summary>
    /// 有効か
    /// </summary>
    public static bool Enabled { get; set; }

    //--------------------------------------------------

    void Awake()
    {
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
			MainGameManager.isGameEnd = true;       // ゲーム終了
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
