using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameController {
    [Serializable]
    public class GameStateBase : IStateBase {
        [SerializeField] string name;

        [Header("Events")]
        [SerializeField] UnityEvent enterEvent;
        [SerializeField] UnityEvent updateEvent;
        [SerializeField] UnityEvent exitEvent;


        public string Name => name;
        public UnityEvent EnterEvent => enterEvent;
        public UnityEvent UpdateEvent => updateEvent;
        public UnityEvent ExitEvent => exitEvent;
    }
}