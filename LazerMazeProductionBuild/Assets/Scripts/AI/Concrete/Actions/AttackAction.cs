using Assets.Scripts.AI.Abstract;

namespace Assets.Scripts.AI.Concrete.Actions {
    public class AttackAction : AiAction {
        public override void Act(StateController stateController) {
            if (stateController.owner.IsDistanceLessOrEqualThan(stateController.owner.player.position, stateController.owner.AttackRange)) {
                stateController.owner.componentManager.attackerComponent.Attack(stateController.owner.playerAttackable);
                UnityEngine.Debug.Log("Attacking");
            }
        }
    }
}
