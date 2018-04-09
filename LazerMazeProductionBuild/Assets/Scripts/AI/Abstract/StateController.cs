using Assets.Scripts.Interactables.Concrete.Components;

namespace Assets.Scripts.AI.Abstract {
    public class StateController {
        public AiState currentState;
        public Enemy owner { get; set; }
        public StateController(AiState startingState, Enemy owner) {
            this.owner = owner;
            currentState = startingState;
        }
        public void Transition(AiState stateToTransition) {
            if (currentState != stateToTransition) {
                currentState.OnStateExit(this);
                currentState = stateToTransition;
                currentState.OnStateEnter(this);
                UnityEngine.Debug.Log("Entering : " + stateToTransition.stateTag);
            }
        }

        public void Tick() {
            currentState.OnStateUpdate(this);
        }
    }
}
