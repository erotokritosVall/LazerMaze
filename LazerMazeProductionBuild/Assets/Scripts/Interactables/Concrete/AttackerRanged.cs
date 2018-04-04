using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete {
    class AttackerRanged : Attacker {

        [SerializeField]
        private GameObject laser;

        private void Awake() {
            AttackDamage = 5.0f;
            TimePassedSincePreviousAttack = AttackRechargeTimer = 0.8f;
        }

        protected override void Attack(Attackable target = null) {
            Instantiate(laser, transform.position, Quaternion.identity);
        }
    }
}
