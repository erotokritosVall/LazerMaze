using Assets.Scripts.Interactables.Concrete.Components;

namespace Assets.Scripts.AI.Abstract {

    public class StateController {

        private AiState currentState;
        public AiState nextState;
        public Enemy Owner { get; private set; }

        public StateController(AiState startingState, Enemy owner) {
            Owner = owner;
            currentState = nextState = startingState;
        }

        public void StartUp() {
            if (currentState != null && nextState != null) {
                currentState.OnStateEnter(this);
            }
        }

        public void OnStateChange(StateTag stateTag) {
            nextState = Owner.GetState(stateTag);
        }

        public void Tick() {
            if (currentState != nextState) {
                currentState.OnStateExit(this);
                currentState = nextState;
                currentState.OnStateEnter(this);
            } else {
                currentState.OnStateUpdate(this);
            }
        }
    }
}
