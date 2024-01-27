using UnityEngine;

namespace Scrips {
    public abstract class State {
        private StateMachine _stateMachine;

        protected State(StateMachine stateMachine) {
            this._stateMachine = stateMachine;
        }

        public virtual void OnEnter() {
            Debug.Log("Enter State " + this);
        }

        public virtual void OnExit() {
            Debug.Log("Exit State " + this);
        }

        public virtual void Execute() {
            Debug.Log("Execute State " + this);
        }
    }
}