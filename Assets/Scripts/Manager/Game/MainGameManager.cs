using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using GameController;

public class MainGameManager : MonoBehaviour
{
    [SerializeField] GameStateMachine state;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    private void Start()
    {
        BGM.Instance.Play(AudioNames.BGM_PALETTE, 0, 0.5f, 1);
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
