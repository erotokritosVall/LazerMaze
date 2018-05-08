using Assets.Scripts.AI.Abstract;
using Assets.Scripts.Interactables.Concrete.Controllers;

namespace Assets.Scripts.AI.Concrete.Conditions {

    public class ChaseToAttackConditionMelee : AiCondition {

        public override bool CheckCondition(StateController stateController) {
            if (stateController.Owner.IsDistanceLessOrEqualThan(PlayerController.Instance.transform.position,
                stateController.Owner.AttackRange)) {
                stateController.nextState = stateController.Owner.GetState(StateTag.Attacking);
                return true;
            }
            return false;
        }
    }
}
