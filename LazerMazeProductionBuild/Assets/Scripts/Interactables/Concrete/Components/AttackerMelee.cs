using Assets.Scripts.Interactables.Abstract;
using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Component that handles melee attacks
     */

    public class AttackerMelee : Attacker {

        [HideInInspector]
        public Attackable target = null;

        protected virtual void Awake() {
            AttackDamage = 5.0f;
            AttackRechargeTimer = 1.0f;
            nextAttackTime = Time.time;
        }

        public override bool IsAbleToAttack() {
            return (Time.time >= nextAttackTime);
        }

        public override void Attack() {
            if (target != null) {
                target.OnHit(AttackDamage);
                nextAttackTime = Time.time + AttackRechargeTimer;
            }
        }
    }
}
