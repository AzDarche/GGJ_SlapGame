using System.Collections;
using Scrips.States;
using UnityEngine;

namespace Scrips {
    public class StateMachine : MonoBehaviour {
        
        public static StateMachine Instance { get; private set; }

        private State _currentState;
        private State _pastState;
        private FacePartStats _faceObjective;
        [SerializeField] private EnemyTurnControl _enemyTurnControl;
        public GameObject precisionBar;
        public GameObject powerBar;
        public GameObject faceSelector;
        public GameObject onomatopeyasPlayer;
        public GameObject onomatopeyasEnemy;
        public int damage;

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
            if (Input.GetKeyDown(KeyCode.Space)) _currentState.Execute();
        }

        public void ChangeState(State newState) {
            _currentState?.OnExit();
            _currentState = newState;
            _currentState.OnEnter();
        }
        
        public IEnumerator ChangeState(State newState, int seconds) {
            yield return new WaitForSeconds(seconds);
            ChangeState(newState);
        }

        public void ReturnState() {
            ChangeState(_pastState);
        }

        public void StorePastState(State pastState) {
            _pastState = pastState;
        }

        public void SetObjective(FacePartStats part) {
            _faceObjective = part;
        }

        public void ApplyDamage() {
            _faceObjective.TakeDamage(damage);
        }

        public IEnumerator HandleEnemyTurn() {
            _enemyTurnControl.DamageRandomPart();
            yield return new WaitForSeconds(2);
            ChangeState(new PlayerTurnState(this));
        }
    }
}