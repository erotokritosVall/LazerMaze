using Assets.Scripts.Interactables.Abstract;
using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Component that handles melee attacks
     */
    public class AttackerMelee : Attacker {
        public Attackable target;

        protected virtual void Awake() {
            AttackDamage = 5.0f;
            AttackRechargeTimer = timePassedSincePreviousAttack = 1.0f;
        }

        public override void Tick() {
            if (timePassedSincePreviousAttack < AttackRechargeTimer) {
                timePassedSincePreviousAttack += Time.deltaTime;
            }
        }

        public override bool IsAbleToAttack() {
            return (timePassedSincePreviousAttack >= AttackRechargeTimer);
        }

        public override void Attack() {
            if (target != null) {
                target.OnHit(AttackDamage);
                timePassedSincePreviousAttack = 0.0f;
            }
        }
    }
}
