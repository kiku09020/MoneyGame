using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController {
    public abstract class GameStateBase : MonoBehaviour,IStateBase {
        public virtual void StateEnter() { }
        public virtual void StateUpdate() { }
        public virtual void StateExit() { }
    }
}