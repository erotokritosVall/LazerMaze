using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.States {

    public class PatrolState : BasicAiState {

        private static readonly float patrolSpeed = 2.0f;
        private float cachedSpeed;

        public PatrolState(AiAction[] actions, AiCondition[] conditions) : base(actions, conditions) { }

        public override void OnStateEnter(StateController stateController) {
            cachedSpeed = stateController.Owner.movableComponent.MoveSpeed;
            stateController.Owner.movableComponent.MoveSpeed = patrolSpeed;
        }

        public override void OnStateExit(StateController stateController) {
            stateController.Owner.movableComponent.MoveSpeed = cachedSpeed;
            base.OnStateExit(stateController);
        }
    }
}
