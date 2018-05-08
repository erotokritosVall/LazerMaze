namespace Assets.Scripts.AI.Abstract {

    /**
     * Base class for AI states, provides the default AIState constructor.
     * Each state requires one or more AIActions and AIConditions to work.
     */

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
