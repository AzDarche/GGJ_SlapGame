using UnityEngine;

namespace Scrips.States {
    public class ApplyDamageState : State {
        private GameObject _onomatopeya;

        public ApplyDamageState(StateMachine stateMachine) : base(stateMachine) {
        }

        public override void OnEnter() {
            base.OnEnter();
            _onomatopeya = _stateMachine.onomatopeyasEnemy.transform.GetChild(Random.Range(0, 2)).gameObject;
            _onomatopeya.SetActive(true);
            _stateMachine.ApplyDamage();
        }

        public override void Execute() {
            base.Execute();
            _stateMachine.ChangeState(new EnemyTurnState(_stateMachine));
        }

        public override void OnExit() {
            base.OnExit();
            _onomatopeya.SetActive(false);
        }
    }
}