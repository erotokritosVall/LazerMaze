using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.States {
    public class BasicAiState : AiState {
        public BasicAiState(AiAction[] actions, AiCondition[] conditions) : base(actions, conditions) { }
        public override void OnStateEnter(StateController stateController) {
            stateController.owner.ClearWaypoints();
        }

        public override void OnStateExit(StateController stateController) {
            stateController.owner.NextNode = stateController.owner.transform.position;
        }

        public override void OnStateUpdate(StateController stateController) {
            for (int i = 0; i < actions.Length; i++) {
                actions[i].Act(stateController);
            }
            for (int i = 0; i < conditions.Length; i++) {
                if (conditions[i].CheckCondition(stateController)) {
                    return;
                }
            }           
        }
    }
}
