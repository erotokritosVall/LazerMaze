using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Conditions {
    class AttackConditionMelee : AiCondition {

        public override bool CheckCondition(StateController stateController) {
            if (!stateController.owner.IsDistanceLessOrEqualThan(stateController.owner.Player.position,
                stateController.owner.AttackRange)) {
                stateController.nextState = stateController.owner.GetState(StateTag.Chasing);
                return true;
            }
            return false;
        }
    }
}
