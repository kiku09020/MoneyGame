using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test {
    public class InsTest : MonoBehaviour {
        [SerializeField,HideInInspector] int hp;

        public int HP { get => hp; set { hp = value; } }

        //--------------------------------------------------

        void Awake()
        {
            print($"HP={hp}");
        }
    }
}