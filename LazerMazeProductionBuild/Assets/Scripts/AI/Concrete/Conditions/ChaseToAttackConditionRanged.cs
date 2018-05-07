using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Conditions {

    public class ChaseToAttackConditionRanged : AiCondition {

        public override bool CheckCondition(StateController stateController) {
            if (stateController.Owner.IsTargetInView(stateController.Owner.AttackRange)) {
                stateController.nextState = stateController.Owner.GetState(StateTag.Attacking);
                return true;
            }
            return false;
        }
    }
}
