using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.States {

    /**
     * Provides the basic shared functionality of concrete AI states
     */

    public class BasicAiState : AiState {

        public BasicAiState(AiAction[] actions, AiCondition[] conditions) : base(actions, conditions) { }

        public override void OnStateEnter(StateController stateController) {
            stateController.Owner.NextNode = stateController.Owner.transform.position;
            stateController.Owner.ClearPath();
        }

        public override void OnStateUpdate(StateController stateController) {
            for (int i = 0; i < StateActions.Length; i++) {
                StateActions[i].Act(stateController);
            }
            for (int i = 0; i < StateConditions.Length; i++) {
                if (StateConditions[i].CheckCondition(stateController)) {
                    return;
                }
            }           
        }

        public override void OnStateExit(StateController stateController) { }
    }
}
