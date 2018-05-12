using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Conditions {

    /**
     * Empty condition to be used in Flee State, because the state machine will not work otherwise
     * Objects never change if they get in Flee state so just return false.
     */

    public class EmptyCondition : AiCondition {

        public override bool CheckCondition(StateController stateController) {
            return false;
        }
    }
}
