using System;
using System.Collections;
using Scrips.States;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scrips {
    public class PrecisionBar : MonoBehaviour {

        public int damage;
        [SerializeField] private int damageAccumulated = 1;
        [SerializeField] private GameObject difficultyBar;
        [SerializeField] private GameObject cursor;
        private float _missFactor;
        private bool _isStopped;
        private const float MaxYPos = 2.6f;
        private const float MinScale = 0.35f;
        private float _cursorSpeed = 2f;
        private float _cursorVelocity;
        private Transform _cursorTransform;
        private Transform _difficultyTransform;
        private StateMachine _stateMachine;
    
        private void Awake() {
            _stateMachine  = StateMachine.Instance;
        }

        public void Initialize() {
            damageAccumulated = _stateMachine.damage;
            _missFactor = 5 - damageAccumulated;
            SetDifficultyBar();
            SetCursor();
        }

        public void ReStart() {
            _isStopped = false;
            _cursorSpeed = 2;
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space) && !_isStopped){
                CalculateDamage();
                _isStopped = true;
                _stateMachine.damage = damage;
                StartCoroutine(ChangeState());
            }
        }

        private void FixedUpdate() {
            if (_isStopped)
                return;
            MoveCursor();
        }

        private void SetCursor() {
            _cursorSpeed *= 2 + damageAccumulated;
            _cursorTransform = cursor.transform;
            _cursorVelocity = _cursorSpeed;
        }

        private void MoveCursor() {
            var position = _cursorTransform.position;
            _cursorVelocity = position.y switch {
                > 2.6f => _cursorSpeed * -1f,
                < -2.6f => _cursorSpeed,
                _ => _cursorVelocity
            };
            position.y += _cursorVelocity * Time.fixedDeltaTime;
            _cursorTransform.position = position;
        }
    
        private void SetDifficultyBar() {
            _difficultyTransform = difficultyBar.transform;
            var scaleMultiplayer = (_missFactor*_missFactor * 5 / 100) + 1;
            _difficultyTransform.localScale = new Vector3(1f, MinScale * scaleMultiplayer, 1);
            _difficultyTransform.position = new Vector3(0f, Random.Range(-MaxYPos, MaxYPos), -1);
        }

        private void CalculateDamage() {
            var cursorPosition = _cursorTransform.position.y;
            var difficultyPosition = _difficultyTransform.position.y;
            var difference = Math.Abs(difficultyPosition - cursorPosition);
            var tempDamage = (2 + _missFactor - difference) * 100 / (2 + _missFactor);
            damage = tempDamage switch {
                > 80 => 100,
                > 50 => 75,
                > 10 => 50,
                _ => 0
            };
            damage = damage / 100 * damageAccumulated;
        }

        private IEnumerator ChangeState() {
            yield return new WaitForSeconds(2);
            _stateMachine.ChangeState(new ApplyDamageState(_stateMachine));
        }
    
    }
}
