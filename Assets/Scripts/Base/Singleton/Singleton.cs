using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : SimpleSingleton<T> where T:Singleton<T>
{
	sealed protected override void RemoveDuplicates()
	{
		// シーン上に無ければ新規作成
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
