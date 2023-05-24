using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.UI.UIController {
    [CreateAssetMenu(fileName = "UIAnimData", menuName = "ScriptableObject/UIAnimData")]
    public class UIAnimData : ScriptableObject {

        [SerializeField] float duration;

    }
}
