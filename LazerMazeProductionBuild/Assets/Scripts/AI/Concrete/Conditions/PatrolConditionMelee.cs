using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Conditions {
    public class PatrolConditionMelee : AiCondition {
        public override bool CheckCondition(StateController stateController) {
            if (stateController.owner.IsDistanceLessOrEqualThan(stateController.owner.Player.position, 10)) {
                stateController.nextState = stateController.owner.GetState(StateTag.Chasing);
                return true;
            }
            return false;
        }
    }
}
