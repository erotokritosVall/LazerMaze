using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Actions {

    public class AttackRangedAction : AiAction {

        public override void Act(StateController stateController) {
            if (stateController.Owner.IsTargetInView(stateController.Owner.AttackRange) && stateController.Owner.attackerComponent.IsAbleToAttack()) {
                stateController.Owner.animatedComponent.OnShootEnable();
                stateController.Owner.attackerComponent.Attack();
            }
        }
    }
}
