namespace Scrips.States {
    
    public class PlayerTurnState : State {
        
        public PlayerTurnState(StateMachine stateMachine) : base(stateMachine) { }

        public override void Execute() {
            base.Execute();
            _stateMachine.ChangeState(new SelectObjectiveState(_stateMachine));
        }
    }
}