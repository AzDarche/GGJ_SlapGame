using UnityEngine;

namespace Scrips.States {
    public class EnemyTurnState : State {
        public EnemyTurnState(StateMachine stateMachine) : base(stateMachine) {
        }

        private GameObject _onomatopeya;

        public override void OnEnter() {
            base.OnEnter();
            _stateMachine.StartCoroutine(_stateMachine.HandleEnemyTurn());
            _onomatopeya = _stateMachine.onomatopeyasPlayer.transform.GetChild(Random.Range(0, 2)).gameObject;
            _onomatopeya.SetActive(true);
        }

        public override void OnExit() {
            base.OnExit();
            _onomatopeya.SetActive(false);
        }
    }
}