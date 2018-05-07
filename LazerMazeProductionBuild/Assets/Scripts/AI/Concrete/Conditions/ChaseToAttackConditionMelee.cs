using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Conditions {

    public class ChaseToAttackConditionMelee : AiCondition {

        public override bool CheckCondition(StateController stateController) {
            if (stateController.Owner.IsDistanceLessOrEqualThan(stateController.Owner.Player.position,
                stateController.Owner.AttackRange)) {
                stateController.nextState = stateController.Owner.GetState(StateTag.Attacking);
                return true;
            }
            return false;
        }
    }
}
