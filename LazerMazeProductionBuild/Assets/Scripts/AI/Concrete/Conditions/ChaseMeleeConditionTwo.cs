using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Conditions {
    public class ChaseMeleeConditionTwo : AiCondition {
        public override bool CheckCondition(StateController stateController) {
            if (!stateController.owner.IsDistanceLessOrEqualThan(stateController.owner.player.position,
                stateController.owner.ChaseRange)) {
                stateController.stateToTransition = stateController.owner.GetStateByTag(StateTag.Patroling);
                return true;
            }
            return false;
        }
    }
}
