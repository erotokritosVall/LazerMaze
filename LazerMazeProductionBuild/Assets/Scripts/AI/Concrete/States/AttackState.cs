using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.States {
    public class AttackState : BasicAiState {

        public AttackState(AiAction[] actions, AiCondition[] conditions) : base(actions, conditions) {
            stateTag = StateTag.Attacking;
        }
    }
}
