using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Goods {

    public class Goods : MonoBehaviour {

        [Header("Components")]
        [SerializeField] RectTransform rectTransform;

        // Properties
        public RectTransform RectTransform => rectTransform;

        //--------------------------------------------------
    }
}