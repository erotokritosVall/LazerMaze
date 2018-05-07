namespace Assets.Scripts.AI.Abstract {

    public abstract class AiState {

        public AiAction[] StateActions { get; private set; }
        public AiCondition[] StateConditions { get; private set; }

        public AiState(AiAction[] actions, AiCondition[] conditions) {
            StateActions = actions;
            StateConditions = conditions;
        }

        public abstract void OnStateEnter(StateController stateController);
        public abstract void OnStateExit(StateController stateController);
        public abstract void OnStateUpdate(StateController stateController);
    }
}
