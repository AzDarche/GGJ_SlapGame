using Scrips.States;
using UnityEngine;

namespace Scrips {
    public class StateMachine : MonoBehaviour {
        
        public static StateMachine Instance { get; private set; }

        private State _currentState;
        private State _pastState;

        private void Awake() {
            //Singleton Logic
            if  (Instance != null && Instance != this)
                Destroy(this);
            Instance = this;
            ChangeState(new StartMatchState(this));
        }

        public void ChangeState(State newState) {
            _currentState?.OnExit();
            _currentState = newState;
            _currentState.OnEnter();
        }

        private void ReturnState() {
            ChangeState(_pastState);
        }

        public void StorePastState(State pastState) {
            _pastState = pastState;
        }

        public void ExecuteState() {
            _currentState.Execute();
        }
    }
}