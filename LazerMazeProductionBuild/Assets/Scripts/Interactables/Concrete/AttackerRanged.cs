using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete {
    public class AttackerRanged : Attacker {

        [SerializeField]
        private GameObject laser;
        
        public Vector3 LaserDirection { get; set; }
 
        private void Awake() {
            AttackDamage = 5.0f;
            TimePassedSincePreviousAttack = AttackRechargeTimer = 0.8f;
            LaserDirection = Vector3.zero;
        }

        private Quaternion LaserRotation() {
            return Quaternion.Euler(90, LaserDirection.z * 90, 0);
        }

        public override void Attack(Attackable target = null) {
            if (TimePassedSincePreviousAttack >= AttackRechargeTimer) {
                LaserController laserController = Instantiate(laser, transform.position, LaserRotation()).GetComponent<LaserController>();
                laserController.SetValues(LaserDirection);
            }
        }
    }
}
