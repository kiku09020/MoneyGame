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

	// �������̏���
	public void Generated(MoneyGroupUnit moneyGroup)
	{
		CurrentMG = moneyGroup;
	}

	/// <summary>
	/// ���݂�MG��ύX(����ւ�)����
	/// </summary>
	public void ChangeCurrentMG()
	{
		var swap = CurrentMG;
		CurrentMG = CurrentMG.targetMG;
		CurrentMG.targetMG = swap;
	}

	/// <summary>
	/// �{�^����OnClick()��Action��ǉ�
	/// </summary>
	public void AddButtonActions()
	{
		if (CurrentMG) {
			// ���݂�MG�̃{�^���ɒǉ�
			CurrentMG.AddButtonAction(() => {
				var target = CurrentMG.TargetMoney;

				if (target != null) {
					target.Mover.ButonMove();
				}
			});

			// ���������MG�̃{�^���ɒǉ�
			CurrentMG.targetMG?.AddButtonAction(() => {
				var target = CurrentMG.targetMG.TargetMoney;

				if (target != null) {
					target.Mover.ButonMove();
				}
			});
		}
	}
}
