using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.States {
    public class ChasingState : BasicAiState {
        public ChasingState(AiAction[] actions, AiCondition[] conditions) : base(actions, conditions) { }
    }
}
