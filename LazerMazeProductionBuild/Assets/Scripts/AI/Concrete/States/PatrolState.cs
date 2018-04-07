using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.States {
    public class PatrolState : BasicAiState {
        protected const float patrolSpeed = 2.0f;
        private float cachedSpeed;
        public PatrolState(AiAction[] actions, AiCondition[] conditions) : base(actions, conditions) {
            stateTag = StateTag.Patroling;
        }
        public override void OnStateEnter(StateController stateController) {
            cachedSpeed = stateController.owner.componentManager.movableComponent.MoveSpeed;
            stateController.owner.componentManager.movableComponent.MoveSpeed = patrolSpeed;
        }

        public override void OnStateExit(StateController stateController) {
            stateController.owner.componentManager.movableComponent.MoveSpeed = cachedSpeed;
            base.OnStateExit(stateController);
        }
    }
}
