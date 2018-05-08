using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Conditions {

    /**
     * Goes from Chase to Attack if Player is in line of sight
     */

    public class ChaseToAttackConditionRanged : AiCondition {

        public override bool CheckCondition(StateController stateController) {
            if (stateController.Owner.IsPlayerInView(stateController.Owner.AttackRange)) {
                stateController.nextState = stateController.Owner.GetState(StateTag.Attacking);
                return true;
            }
            return false;
        }
    }
}
