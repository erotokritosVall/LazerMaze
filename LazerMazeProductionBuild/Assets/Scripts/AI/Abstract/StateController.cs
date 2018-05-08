using Assets.Scripts.Interactables.Concrete.Components;

namespace Assets.Scripts.AI.Abstract {

    /**
     * The basis of the Finite State Machine , responsible for calling each states functionallity.
     * Each enemy is required to have one.
     * Owner variable is used to provide states the information they need to work. (for example calling component's functions etc)
     */

    public class StateController {

        private AiState currentState;

        public AiState nextState;
        public Enemy Owner { get; private set; }

        public StateController(AiState startingState, Enemy owner) {
            Owner = owner;
            currentState = nextState = startingState;
        }

        //Startup should be manually called through the owner before calling tick on the state machine
        public void StartUp() {
            currentState.OnStateEnter(this);
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
