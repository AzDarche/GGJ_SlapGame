namespace Scrips.States {
    public class PowerBarState : State {
        public PowerBarState(StateMachine stateMachine) : base(stateMachine) { }

        public override void OnEnter() {
            base.OnEnter();
            _stateMachine.powerBar.gameObject.SetActive(true);
        }

        public override void OnExit() {
            base.OnExit();
            _stateMachine.powerBar.gameObject.SetActive(false);
        }
    }
}