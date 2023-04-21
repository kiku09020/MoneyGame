using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money:MonoBehaviour
{
	[Header("Data")]
    [SerializeField] MoneyData data;

	// MoneyGroupUnits
	public MoneyGroupUnit CurrentMG { get; private set; }

	[Header("Components")]
	[SerializeField] RectTransform rectTransform;
	[SerializeField] Image image;
	[SerializeField] MoneyMover mover;

    // Proparties
    public MoneyData Data => data;

	public RectTransform RectTransform => rectTransform;
	public MoneyMover Mover => mover;

	//--------------------------------------------------

	private void OnValidate()
	{
		if (data != null) {
			image.sprite = data.Sprite;
		}
	}

	// 生成時の処理
	public void Generated(MoneyGroupUnit moneyGroup)
	{
		CurrentMG = moneyGroup;
	}

	/// <summary>
	/// 現在のMGを変更(入れ替え)する
	/// </summary>
	public void ChangeCurrentMG()
	{
		var swap = CurrentMG;
		CurrentMG = CurrentMG.targetMG;
		CurrentMG.targetMG = swap;
	}

	/// <summary>
	/// ボタンのOnClick()にActionを追加
	/// </summary>
	public void AddButtonActions()
	{
		if (CurrentMG) {
			// 現在のMGのボタンに追加
			CurrentMG.AddButtonAction(() => {
				var target = CurrentMG.TargetMoney;

				if (target != null) {
					target.Mover.ButonMove();
				}
			});

			// もう一方のMGのボタンに追加
			CurrentMG.targetMG?.AddButtonAction(() => {
				var target = CurrentMG.targetMG.TargetMoney;

				if (target != null) {
					target.Mover.ButonMove();
				}
			});
		}
	}
}
