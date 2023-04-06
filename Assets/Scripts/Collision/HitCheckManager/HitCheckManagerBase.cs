using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitCheckManagerBase <T> : MonoBehaviour where T:HitCheckerBase
{
    [SerializeField] protected List<T> hitCheckerList = new List<T>();

    //--------------------------------------------------

    /// <summary>
    /// Žw’è‚ÌHitChekcer‚ðŽæ“¾
    /// </summary>
    public HitCheck GetHitChecker<HitCheck>() where HitCheck:T
    {
        foreach (var hitCheckr in hitCheckerList) {
            if (hitCheckr is HitCheck target) {
                return target;
            }
        }

        LogController.ColoredLog($"{nameof(HitCheck)} doesn`t exist.", Color.red);
        return null;
    }
}
