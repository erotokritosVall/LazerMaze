using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete {
    public class AttackerMelee : Attacker {
        private void Awake() {
            AttackDamage = 5.0f;
            AttackRechargeTimer = TimePassedSincePreviousAttack = 0.8f;
        }

        public override void Attack(Attackable target = null) {
            if (TimePassedSincePreviousAttack >= AttackRechargeTimer) {
                if (target != null) {
                    target.OnHit(AttackDamage);
                }
            }
        }
    }
}
