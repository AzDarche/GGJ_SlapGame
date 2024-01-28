namespace Scrips.States {
    
    public class PlayerTurnState : State {
        
        public PlayerTurnState(StateMachine stateMachine) : base(stateMachine) { }

        public override void OnEnter() {
            base.OnEnter();
            if (_stateMachine.turns >= 4)
                _stateMachine.CalculateWinner();
            _stateMachine.turns ++;
        }

        public override void Execute() {
            base.Execute();
            _stateMachine.ChangeState(new SelectObjectiveState(_stateMachine));
        }
    }
}