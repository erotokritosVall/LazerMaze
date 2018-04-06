using UnityEngine;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete {

    /**
     * Component that handles melee attacks
     */
    public class AttackerMelee : Attacker {
        protected virtual void Awake() {
            AttackDamage = 5.0f;
            AttackRechargeTimer = TimePassedSincePreviousAttack = 0.8f;
        }

        private void Update() {
            if (TimePassedSincePreviousAttack < AttackRechargeTimer) {
                TimePassedSincePreviousAttack += Time.deltaTime;
            }
        }

        public override void Attack(Attackable target = null) {
            if (TimePassedSincePreviousAttack >= AttackRechargeTimer) {
                if (target != null) {
                    target.OnHit(AttackDamage);
                    TimePassedSincePreviousAttack = 0.0f;
                }
            }
        }
    }
}
