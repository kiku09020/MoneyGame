using Game.Money.MoneyManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public abstract class EvaluationUnit:MonoBehaviour {
	[Header("Messages")]
	[SerializeField,Tooltip("評価メッセージ")]		protected string message;
	[SerializeField,Tooltip("評価メッセージの色")]	protected Color messageColor;

	[Header("SubEvents")]
	[SerializeField,Tooltip("サブイベント")] UnityEvent subEvent;

	[Header("Components")]
	[SerializeField] protected WholeMoneyInfo moneyInfo;

	//--------------------------------------------------
	// Properties
	/// <summary>
	/// 評価メッセージ
	/// </summary>
	public string Message => message;

	/// <summary>
	/// 評価メッセージのテキストの色
	/// </summary>
	public Color MessageColor => messageColor;

	//--------------------------------------------------

	/// <summary>
	/// サブイベント。スクリプトから追加したい場合に利用する
	/// </summary>
	public event EventHandler EvaluateSubEvent;

	/// <summary>
	/// 評価の条件
	/// </summary>
	protected virtual bool Condition(){ return true; }

	/// <summary>
	/// 評価
	/// </summary>
	public void Evaluate()
	{
		if (Condition()) {
			CommonAction();		// 実行

			// サブイベント群を実行
			EvaluateSubEvent?.Invoke(this, EventArgs.Empty);
			subEvent?.Invoke();
		}
	}

	//--------------------------------------------------

	/// <summary>
	/// 共通処理
	/// </summary>
	void CommonAction()
	{

	}

	public void Exit()
	{

	}
}
