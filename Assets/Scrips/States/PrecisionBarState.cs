namespace Scrips.States {
    public class PrecisionBarState : State {
        public PrecisionBarState(StateMachine stateMachine) : base(stateMachine) {
        }

        public override void OnEnter() {
            base.OnEnter();
            _stateMachine.precisionBar.gameObject.SetActive(true);
            _stateMachine.precisionBar.GetComponent<PrecisionBar>().damage = _stateMachine.damage;
        }

        public override void OnExit() {
            base.OnExit();
            _stateMachine.precisionBar.gameObject.SetActive(false);
        }
    }
}