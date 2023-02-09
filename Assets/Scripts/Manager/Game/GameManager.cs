using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameController;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameStateMachine state;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();

        state.StateInit(GameStateMachine.TitleState);

        BGM.Instance.Play(AudioNames.BGM_PALETTE);
    }

	private void Update()
	{

	}

	// Update is called once per frame
	void FixedUpdate()
    {
        state.StateUpdate();
    }
}
