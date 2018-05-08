using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.States {

    /**
     * Extends basic state functionality as needed.
     * Objects on patrol move slower than when chasing so we need to cache the regural speed and change it again when exiting the state
     */

    public class PatrolState : BasicAiState {

        private static readonly float patrolSpeed = 2.0f;
        private float cachedSpeed;

        public PatrolState(AiAction[] actions, AiCondition[] conditions) : base(actions, conditions) { }

        public override void OnStateEnter(StateController stateController) {
            cachedSpeed = stateController.Owner.movableComponent.MoveSpeed;
            stateController.Owner.movableComponent.MoveSpeed = patrolSpeed;
            base.OnStateEnter(stateController);
        }

        public override void OnStateExit(StateController stateController) {
            stateController.Owner.movableComponent.MoveSpeed = cachedSpeed;
            base.OnStateExit(stateController);
        }
    }
}
