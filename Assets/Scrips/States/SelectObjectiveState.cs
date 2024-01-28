namespace Scrips.States {
    public class SelectObjectiveState : State {
        
        public SelectObjectiveState(StateMachine stateMachine) : base(stateMachine) { }

        public override void OnEnter() {
            base.OnEnter();
            _stateMachine.objectiveSelector.gameObject.SetActive(true);
        }

        public override void OnExit() {
            base.OnExit();
            _stateMachine.objectiveSelector.gameObject.SetActive(false);
        }
    }
}