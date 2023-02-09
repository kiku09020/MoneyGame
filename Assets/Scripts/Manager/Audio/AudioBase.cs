using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioBase<T> : Singleton<T> where T: AudioBase<T>
{
	/// <summary>
	/// Resourcesのファイルパス
	/// </summary>
	protected abstract string FilePath { get; }

	protected AudioSource source;
	protected Dictionary<string, AudioClip> dict = new Dictionary<string, AudioClip>();

	protected override void Awake()
	{
		base.Awake();

		Setup();
		GetAudioFiles();
	}

	/// <summary>
	/// AudioSourceのセットアップ
	/// </summary>
	protected virtual void Setup()
    {
		source = gameObject.AddComponent<AudioSource>();
		source.playOnAwake = false;
    }

	// 音声ファイルを取得して、Dictionaryに格納
	void GetAudioFiles()
	{
		object[] list = Resources.LoadAll(FilePath);

		foreach (AudioClip clip in list) {
			dict[clip.name] = clip;
		}
	}

	//-------------------------------------------

	/// <summary>
	/// 音声の再生
	/// </summary>
	public virtual void Play(string audioName, float delay = 0, float volume = 1, float pitch = 1)
	{
		// 指定された音声ファイル名が存在しない場合
        if (!dict.ContainsKey(audioName)) {
			LogController.ColoredLog("指定された音声は存在しません。", Color.red);
			return;
        }

		// 音声再生
        else {
			StartCoroutine(PlayBase(audioName, delay, volume, pitch));
        }
	}

	// delay用コルーチン
	IEnumerator PlayBase(string audioName,float delay=0,float volume=1,float pitch = 1)
    {
		// 待機
		yield return new WaitForSecondsRealtime(delay);

		// 設定
		source.volume = volume;
		source.pitch = pitch;

		// 再生
		var clip = dict[audioName];
		source.clip = clip;
		source.PlayOneShot(clip);
    }

	//-------------------------------------------

	/// <summary>
	/// 一時停止
	/// </summary>
	public void Pause()
    {
		source.Pause();
    }

	/// <summary>
	///  一時停止解除
	/// </summary>
	public void UnPause()
    {
		source.UnPause();
    }

	/// <summary>
	/// ミュート
	/// </summary>
	public void Mute()
    {
		source.mute = true;
    }
	/// <summary>
	/// ミュート解除
	/// </summary>
	public void UnMute()
    {
		source.mute = false;
    }

	/// <summary>
	/// 停止
	/// </summary>
	public void Stop()
    {
		source.Stop();
    }

	/// <summary>
	/// 
	/// </summary>
	public void ChangeVolume(float volume)
    {
		source.volume = volume;
    }

	/// <summary>
	/// ピッチ変更
	/// </summary>
	public void ChangePitch(float pitch)
    {
		source.pitch = pitch;
    }
}
