namespace Assets.Scripts.AI.Abstract {

    /**
     * Base class for AI Conditions. They control when a state switch should be made.
     */

    public abstract class AiCondition {

        public abstract bool CheckCondition(StateController stateController);
    }
}
