using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Actions {

    public class AttackMeleeAction : AiAction {

        public override void Act(StateController stateController) {
            if (stateController.Owner.IsDistanceLessOrEqualThan(stateController.Owner.Player.position, stateController.Owner.AttackRange)
                && stateController.Owner.attackerComponent.IsAbleToAttack()) {
                stateController.Owner.attackerComponent.Attack();
            }
        }
    }
}
