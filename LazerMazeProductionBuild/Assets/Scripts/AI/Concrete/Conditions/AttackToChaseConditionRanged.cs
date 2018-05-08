using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Conditions {

    /**
     * Goes from Attack to Chase if Player is out of line of sight
     */

    public class AttackToChaseConditionRanged : AiCondition {

        public override bool CheckCondition(StateController stateController) {
            if (!stateController.Owner.IsPlayerInView(stateController.Owner.AttackRange)) {
                stateController.nextState = stateController.Owner.GetState(StateTag.Chasing);
                return true;
            }
            return false;
        }
    }
}
