using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Conditions {
    public class PatrolToChaseConditionRanged : AiCondition {

        public override bool CheckCondition(StateController stateController) {
            if (stateController.Owner.IsTargetInView(stateController.Owner.ChaseRange)) {
                stateController.nextState = stateController.Owner.GetState(StateTag.Chasing);
                return true;
            }
            return false;
        }
    }
}
