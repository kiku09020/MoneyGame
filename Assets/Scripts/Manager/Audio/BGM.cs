using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : AudioBase<BGM>
{
    protected override string FilePath => "Audio/BGM";

    protected override void Setup()
    {
        base.Setup();

        source.loop = true;     // ƒ‹[ƒv—LŒø‰»
    }
}
