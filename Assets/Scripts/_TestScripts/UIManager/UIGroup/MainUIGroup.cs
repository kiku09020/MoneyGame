using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Test {
    public class MainUIGroup : UIGroupBase {
        [SerializeField] Button button;

        public override void Initialize()
        {
            button.onClick.AddListener(() => UIManager.ShowUIGroup<SubUIGroup>());
        }
    }
}