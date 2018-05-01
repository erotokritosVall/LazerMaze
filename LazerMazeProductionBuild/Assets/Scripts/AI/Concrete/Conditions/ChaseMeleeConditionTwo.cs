using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Conditions {

    public class ChaseMeleeConditionTwo : AiCondition {

        public override bool CheckCondition(StateController stateController) {
            if (!stateController.owner.IsDistanceLessOrEqualThan(stateController.owner.Player.position,
                stateController.owner.ChaseRange)) {
                stateController.nextState = stateController.owner.GetState(StateTag.Patroling);
                return true;
            }
            return false;
        }
    }
}
