using Assets.Scripts.AI.Abstract;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.AI.Concrete.States {
    public class PatrolState : BasicAiState {
        protected const float patrolSpeed = 2.0f;
        private float cachedSpeed;

        public PatrolState(AiAction[] actions, AiCondition[] conditions) : base(actions, conditions) { }

        public override void OnStateEnter(StateController stateController) {
            cachedSpeed = stateController.owner.GetComponent<Movable>().MoveSpeed;
            stateController.owner.GetComponent<Movable>().MoveSpeed = patrolSpeed;
        }

        public override void OnStateExit(StateController stateController) {
            stateController.owner.GetComponent<Movable>().MoveSpeed = cachedSpeed;
            base.OnStateExit(stateController);
        }
    }
}
