namespace Scrips.States {
    
    public class StartMatchState : State{
        
        public StartMatchState(StateMachine stateMachine) : base(stateMachine) { }

        public override void OnEnter() {
            base.OnEnter();
            _stateMachine.StartCoroutine(_stateMachine.ChangeState(new PlayerTurnState(_stateMachine), 2));
        }
    }
}