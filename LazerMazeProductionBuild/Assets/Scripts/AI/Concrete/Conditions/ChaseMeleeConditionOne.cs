using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Conditions {
    public class ChaseMeleeConditionOne : AiCondition {
        public override bool CheckCondition(StateController stateController) {
            if (stateController.owner.IsDistanceLessOrEqualThan(stateController.owner.player.position,
                stateController.owner.AttackRange)) {
                stateController.stateToTransition = stateController.owner.GetStateByTag(StateTag.Attacking);
                return true;
            }
            return false;
        }
    }
}
