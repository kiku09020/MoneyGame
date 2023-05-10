using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GameController;
using Game.Money.MoneyGroup;

namespace Game.Money {
	public class Money : MonoBehaviour {
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
					if (MainGameManager.isOperable) {

						var target = CurrentMG.TargetMoney;

						if (target != null) {
							target.Mover.ButonMove();
						}
					}
				});

				// ���������MG�̃{�^���ɒǉ�
				CurrentMG.targetMG?.AddButtonAction(() => {
					if (MainGameManager.isOperable) {
						var target = CurrentMG.targetMG.TargetMoney;

						if (target != null) {
							target.Mover.ButonMove();
						}
					}
				});
			}
		}

		//--------------------------------------------------

		/// <summary>
		/// �f�[�^�̔ԍ��œ����������肷��
		/// </summary>
		public static bool operator ==(Money money, Money targetMoney)
		{
			return (money?.data.Number == targetMoney?.data.Number) ? true : false;
		}

		public static bool operator !=(Money money, Money targetMoney)
		{
			return (money?.data.Number != targetMoney?.data.Number) ? true : false;
		}

		public override bool Equals(object other)
		{
			return base.Equals(other);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}