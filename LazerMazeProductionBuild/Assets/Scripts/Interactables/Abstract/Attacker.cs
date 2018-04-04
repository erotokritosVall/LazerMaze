using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {
    public abstract class Attacker : MonoBehaviour {
        public float AttackDamage { get; set; }
        public float AttackRechargeTimer { get; set; }
        public float TimePassedSincePreviousAttack { get; set; }

        public abstract void Attack(Attackable target = null);
    }
}
