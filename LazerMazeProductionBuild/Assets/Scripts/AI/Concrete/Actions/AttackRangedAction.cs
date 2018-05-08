using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Actions {

    /**
     * Basic ranged attacker functionallity. Makes the extra check for line of sight before attacking and calls attack animations
     */

    public class AttackRangedAction : AiAction {

        public override void Act(StateController stateController) {
            if (stateController.Owner.IsPlayerInView(stateController.Owner.AttackRange) && stateController.Owner.attackerComponent.IsAbleToAttack()) {
                stateController.Owner.animatedComponent.OnShootEnable();
                stateController.Owner.attackerComponent.Attack();
            }
        }
    }
}
