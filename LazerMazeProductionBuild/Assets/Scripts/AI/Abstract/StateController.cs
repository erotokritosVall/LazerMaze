using Assets.Scripts.Interactables.Concrete.Components;

namespace Assets.Scripts.AI.Abstract {

    public class StateController {

        public AiState currentState;
        public AiState nextState;
        public Enemy owner { get; set; }

        public StateController(AiState startingState, Enemy owner) {
            this.owner = owner;
            currentState = nextState = startingState;
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
