namespace Scrips.States {
    public class DefeatState : State {
        public DefeatState(StateMachine stateMachine) : base(stateMachine) {
        }

        public override void OnEnter() {
            base.OnEnter();
            _stateMachine.defeatScreen.SetActive(true);
        }

        public override void OnExit() {
            base.OnExit();
            _stateMachine.defeatScreen.SetActive(false);
        }
    }
}