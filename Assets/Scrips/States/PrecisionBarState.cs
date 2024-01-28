namespace Scrips.States {
    public class PrecisionBarState : State {
        public PrecisionBarState(StateMachine stateMachine) : base(stateMachine) {
        }

        private PrecisionBar _handler;

        public override void OnEnter() {
            base.OnEnter();
            _handler = _stateMachine.precisionBar.GetComponent<PrecisionBar>();
            _handler.gameObject.SetActive(true);
            _handler.Initialize();
        }

        public override void OnExit() {
            base.OnExit();
            _handler.gameObject.SetActive(false);
        }
    }
}