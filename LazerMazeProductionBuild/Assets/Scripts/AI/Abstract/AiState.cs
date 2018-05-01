namespace Assets.Scripts.AI.Abstract {

    public abstract class AiState {

        public AiAction[] actions;
        public AiCondition[] conditions;

        public AiState(AiAction[] actions, AiCondition[] conditions) {
            this.actions = actions;
            this.conditions = conditions;
        }

        public abstract void OnStateEnter(StateController stateController);
        public abstract void OnStateExit(StateController stateController);
        public abstract void OnStateUpdate(StateController stateController);
    }
}
