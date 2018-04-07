using Assets.Scripts.Interactables.Concrete.Components;

namespace Assets.Scripts.AI.Abstract {
    public class StateController {
        public AiState currentState;
        public AiState stateToTransition;
        public Enemy owner { get; set; }
        public StateController(AiState startingState, Enemy owner) {
            this.owner = owner;
            currentState = stateToTransition = startingState;
        }
        public void Transition() {
            if (currentState != stateToTransition) {
                currentState.OnStateExit(this);
                currentState = stateToTransition;
                currentState.OnStateEnter(this);
            }
        }

        public void Tick() {
            currentState.OnStateUpdate(this);
        }
    }
}
