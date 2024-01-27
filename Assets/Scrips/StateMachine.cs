using System;
using Scrips.States;
using UnityEngine;

namespace Scrips {
    public class StateMachine : MonoBehaviour {
        
        public static StateMachine Instance { get; private set; }

        private State _currentState;
        private State _pastState;
        public GameObject precisionBar;
        public GameObject powerBar;


        private void Awake() {
            //Singleton Logic
            if  (Instance != null && Instance != this)
                Destroy(this);
            Instance = this;
            //Initialize Machine
            ChangeState(new StartMatchState(this));
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) _currentState.Pause();
        }

        public void ChangeState(State newState) {
            _currentState?.OnExit();
            _currentState = newState;
            _currentState.OnEnter();
        }

        public void ReturnState() {
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