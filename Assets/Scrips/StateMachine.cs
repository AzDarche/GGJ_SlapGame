using Scrips.States;
using UnityEngine;

namespace Scrips {
    public class StateMachine : MonoBehaviour {

        private State _currentState;

        private void Awake() {
            ChangeState(new StartMatchState(this));
        }

        private void ChangeState(State newState) {
            _currentState?.OnExit();
            _currentState = newState;
            _currentState.OnEnter();
        }
    }
}