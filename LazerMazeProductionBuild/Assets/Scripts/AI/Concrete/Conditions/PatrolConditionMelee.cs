using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Conditions {
    public class PatrolConditionMelee : AiCondition {
        public override bool CheckCondition(StateController stateController) {
            if (stateController.owner.IsDistanceLessOrEqualThan(stateController.owner.player.position, 10)) {
                stateController.stateToTransition = stateController.owner.GetStateByTag(StateTag.Chasing);
                return true;
            }
            return false;
        }
    }
}
