using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.States {

    /**
     * Expands basic state functionallity
     */

    public class FleeState : BasicAiState {

        public FleeState(AiAction[] actions, AiCondition[] conditions) : base(actions, conditions) { }

        public override void OnStateEnter(StateController stateController) {
            base.OnStateEnter(stateController);
            stateController.Owner.movableComponent.MoveSpeed = 5.0f;
        }
    }
}
