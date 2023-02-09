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
    }

    private void Start()
    {
        BGM.Instance.Play(AudioNames.BGM_PALETTE,0,0.5f,1);
    }

    private void Update()
	{
        transform.position = ExtendInput.GetMousePosition_World();
	}

	// Update is called once per frame
	void FixedUpdate()
    {
        state.StateUpdate();
    }
}
