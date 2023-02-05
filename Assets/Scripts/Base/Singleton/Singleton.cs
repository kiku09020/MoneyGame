using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : SimpleSingleton<T> where T:Singleton<T>
{
	protected virtual void Awake()
	{
		RemoveDuplicates();
	}

	// インスタンスの重複を削除
	void RemoveDuplicates()
	{
		// シーン上に無ければ
		if (!instance) {
			instance = this as T;
			DontDestroyOnLoad(gameObject);
		}

		// 既にあれば自身を削除
		else {
			Destroy(gameObject);
		}
	}
}
