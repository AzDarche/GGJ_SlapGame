namespace Scrips.States {
    public class VictoryState : State{
        public VictoryState(StateMachine stateMachine) : base(stateMachine) {
        }
        
        public override void OnEnter() {
            base.OnEnter();
            _stateMachine.victoryScreen.SetActive(true);
            _stateMachine.PlayVictory();
        }

        public override void OnExit() {
            base.OnExit();
            _stateMachine.victoryScreen.SetActive(false);
        }
    }
}