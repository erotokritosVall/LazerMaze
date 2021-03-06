﻿using Assets.Scripts.AI.Abstract;
using Assets.Scripts.Interactables.Concrete.Controllers;

namespace Assets.Scripts.AI.Concrete.Actions {

    /**
     * Basic melee attacker functionallity, checks if Player is in attack range before attacking
     */

    public class AttackMeleeAction : AiAction {

        public override void Act(StateController stateController) {
            if (stateController.Owner.IsDistanceLessOrEqualThan(PlayerController.Instance.transform.position, stateController.Owner.AttackRange)
                && stateController.Owner.attackerComponent.IsAbleToAttack()) {
                stateController.Owner.attackerComponent.Attack();
            }
        }
    }
}
