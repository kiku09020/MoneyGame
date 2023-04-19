using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
	public void Generated(MoneyGenerator.MoneyUnit moneyUnit)
	{
		CurrentMG = moneyUnit.PocketMG;
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
	public void AddButtonActions(bool move = true)
	{
		// ���݂�MG�̃{�^���ɒǉ�
		CurrentMG.AddButtonAction(() => {
			var target = CurrentMG.TargetMoney;

			if (target != null) {
				var mg = CurrentMG.MoneyGroup;

				target.Mover.MoveBase();
				mg.AddAmount(data.Amount);
				mg.AddCount();
			}
		});

		// ���������MG�̃{�^���ɒǉ�
		CurrentMG.targetMG.AddButtonAction(() => {
			var target = CurrentMG.targetMG.TargetMoney;

			if (target != null) {
				var mg = CurrentMG.targetMG.MoneyGroup;

				target.Mover.MoveBase();
				mg.AddAmount(data.Amount);
				mg.AddCount();
			}
		});
	}
}
