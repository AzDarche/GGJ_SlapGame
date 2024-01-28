using System.Collections;
using System.Collections.Generic;
using AudioManager;
using Scrips.States;
using UnityEngine;

namespace Scrips {
    public class StateMachine : MonoBehaviour {
        
        public static StateMachine Instance { get; private set; }

        private State _currentState;
        private State _pastState;
        private FacePartStats _faceObjective;
        [SerializeField] private EnemyTurnControl enemyTurnControl;
        [SerializeField] private FacePartSelector facePartSelector;
        public GameObject victoryScreen;
        public GameObject defeatScreen;
        public GameObject precisionBar;
        public GameObject powerBar;
        public GameObject objectiveSelector;
        public GameObject onomatopeyasPlayer;
        public GameObject onomatopeyasEnemy;
        public int damage;
        public int turns;
        [Header("Sound")]
        [SerializeField] private AudioSource backgroundSource;
        [SerializeField] private AudioSource effectsSource;
        [SerializeField] private List<SoundEvent> punchSoundEffects;
        [SerializeField] private SoundEvent backgroundSound;
        [SerializeField] private SoundEvent victorySound;

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
            enemyTurnControl.DamageRandomPart();
            yield return new WaitForSeconds(2);
            ChangeState(new PlayerTurnState(this));
        }

        public void CalculateWinner() {
            if (enemyTurnControl.GetPlayerLife() < facePartSelector.GetEnemyLife())
                ChangeState(new DefeatState(this));
            else 
                ChangeState(new VictoryState(this));
        }

        public void PlayPunch() {
            punchSoundEffects[Random.Range(0, punchSoundEffects.Count)].Play(effectsSource);
        }

        public void PlayBackground() {
            backgroundSound.Play(backgroundSource);
        }

        public void PlayVictory() {
            victorySound.Play(effectsSource);
        }
    }
}