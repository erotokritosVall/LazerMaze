using Assets.Scripts.AI.Abstract;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.AI.Concrete.Actions {
    public class AttackAction : AiAction {
        public override void Act(StateController stateController) {
            if (stateController.owner.IsDistanceLessOrEqualThan(stateController.owner.Player.position, stateController.owner.AttackRange)) {
                if (stateController.owner.attackerComponent.IsAbleToAttack()) {
                    stateController.owner.attackerComponent.Attack();
                }
            }
        }
    }
}
