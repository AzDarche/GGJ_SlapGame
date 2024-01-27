using UnityEngine;

namespace Scrips.States {
    public class PauseState : State {
        public PauseState(StateMachine stateMachine) : base(stateMachine) {
        }

        public override void OnEnter() {
            base.OnEnter();
            Time.timeScale = 0f;
        }

        public override void OnExit() {
            base.OnExit();
            Time.timeScale = 1f;
        }

        public override void Pause() {
            _stateMachine.ReturnState();
        }
    }
}