using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingDataManager : DataManagerBase<SettingDataManager>
{
    protected override string FileName => "SettingData";

    [HideInInspector] public SettingData data;

    protected override void Awake()
    {
        base.Awake();

        data = SetUp<SettingData>(data);
    }

    private void OnDestroy()
    {
        Save(data);
    }
}
