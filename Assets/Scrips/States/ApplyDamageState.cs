namespace Scrips.States {
    public class ApplyDamageState : State {
        public ApplyDamageState(StateMachine stateMachine) : base(stateMachine) {
        }

        public override void OnEnter() {
            base.OnEnter();
            _stateMachine.ApplyDamage();
        }

        public override void Execute() {
            base.Execute();
            _stateMachine.ChangeState(new EnemyTurnState(_stateMachine));
        }
    }
}