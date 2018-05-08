using Assets.Scripts.AI.Abstract;
using Assets.Scripts.Interactables.Concrete.Controllers;

namespace Assets.Scripts.AI.Concrete.Conditions {

    public class PatrolToChaseConditionMelee : AiCondition {

        public override bool CheckCondition(StateController stateController) {
            if (stateController.Owner.IsDistanceLessOrEqualThan(PlayerController.Instance.transform.position, stateController.Owner.ChaseRange)) {
                stateController.nextState = stateController.Owner.GetState(StateTag.Chasing);
                return true;
            }
            return false;
        }
    }
}
