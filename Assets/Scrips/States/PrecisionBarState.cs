namespace Scrips.States {
    public class PrecisionBarState : State {
        public PrecisionBarState(StateMachine stateMachine) : base(stateMachine) {
        }

        public override void OnEnter() {
            base.OnEnter();
            _stateMachine.precisionBar.gameObject.SetActive(true);
        }
    }
}