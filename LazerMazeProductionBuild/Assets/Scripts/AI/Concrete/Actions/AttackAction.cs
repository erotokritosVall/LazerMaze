using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Actions {
    public class AttackAction : AiAction {
        public override void Act(StateController stateController) {
            stateController.owner.componentManager.attackerComponent.Attack(stateController.owner.playerAttackable);
        }
    }
}
