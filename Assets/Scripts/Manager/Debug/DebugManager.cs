using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : Singleton<DebugManager>
{
    protected override void Awake()
    {
		if (Debug.isDebugBuild) {
            LogController.Log("This is Debug Build.", LogTag.Debug);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
