using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Cysharp.Threading.Tasks;
using static UnityEngine.GraphicsBuffer;

public class MoneyMover : MonoBehaviour
{
	[Header("")]
	[SerializeField] Money money;

	[Header("Params")]
	[SerializeField] MovementParams moveParams;

	//--------------------------------------------------

	[Serializable]
	public class MovementParams
	{
		[SerializeField] float duration = 0.25f;
		[SerializeField] Ease easeType = Ease.Unset;

		public float Duration => duration;
	}


    //--------------------------------------------------

    void Awake()
    {
        
    }

	public void MoveBase()
	{
		transform.DOMove(money.CurrentMG.targetMG.transform.position, moveParams.Duration)
			.OnComplete(() => {
				transform.SetParent(money.CurrentMG.RectTransform);      // MG��e�Ɏw��
			});

		money.CurrentMG.targetMG.MoneyList.Add(money);            // �ڕW��MG�̃��X�g�ɒǉ�
		money.CurrentMG.MoneyList.Remove(money);        // ���݂�MG�̃��X�g���珜�O
		money.ChangeCurrentMG();

		money.AddButtonActions();				// �{�^����Action��ύX
	}
}
