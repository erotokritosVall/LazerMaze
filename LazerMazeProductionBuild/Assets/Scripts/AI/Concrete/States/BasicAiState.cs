using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.States {
    public class BasicAiState : AiState {
        public BasicAiState(AiAction[] actions, AiCondition[] conditions) : base(actions, conditions) { }
        public override void OnStateEnter(StateController stateController) { }
        public override void OnStateExit(StateController stateController) {
            stateController.owner.ClearWaypoints();
        }
        public override void OnStateUpdate(StateController stateController) {
            foreach(AiAction action in actions) {
                action.Act(stateController);
            }
            foreach(AiCondition condition in conditions) {
                if (condition.CheckCondition(stateController)) {
                    stateController.Transition();
                    break;
                }
            }
        }
    }
}
