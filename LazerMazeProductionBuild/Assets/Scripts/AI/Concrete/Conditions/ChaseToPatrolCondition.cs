using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Conditions {

    public class ChaseToPatrolCondition : AiCondition {

        public override bool CheckCondition(StateController stateController) {
            if (!stateController.Owner.IsDistanceLessOrEqualThan(stateController.Owner.Player.position,
                stateController.Owner.ChaseRange)) {
                stateController.nextState = stateController.Owner.GetState(StateTag.Patroling);
                return true;
            }
            return false;
        }
    }
}
