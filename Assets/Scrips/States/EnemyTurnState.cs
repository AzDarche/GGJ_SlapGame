namespace Scrips.States {
    public class EnemyTurnState : State {
        public EnemyTurnState(StateMachine stateMachine) : base(stateMachine) {
        }

        public override void OnEnter() {
            base.OnEnter();
            _stateMachine.StartCoroutine(_stateMachine.HandleEnemyTurn());
        }
    }
}