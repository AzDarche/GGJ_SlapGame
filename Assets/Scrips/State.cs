using Scrips.States;
using UnityEngine;

namespace Scrips {
    public abstract class State {
        protected StateMachine _stateMachine;

        protected State(StateMachine stateMachine) {
            this._stateMachine = stateMachine;
        }

        public virtual void OnEnter() {
            Debug.Log("Enter State " + this);
        }

        public virtual void OnExit() {
            _stateMachine.StorePastState(this);
            Debug.Log("Exit State " + this);
        }

        public virtual void Execute() {
            Debug.Log("Execute State " + this);
        }

        public virtual void Pause() {
            _stateMachine.ChangeState(new PauseState(_stateMachine));
        }
    }
}