using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Conditions {

    /**
     * Goes from Patrol to Chase if Player is in line of sight
     */

    public class PatrolToChaseConditionRanged : AiCondition {

        public override bool CheckCondition(StateController stateController) {
            if (stateController.Owner.IsPlayerInView(stateController.Owner.ChaseRange)) {
                stateController.nextState = stateController.Owner.GetState(StateTag.Chasing);
                return true;
            }
            return false;
        }
    }
}
