using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {
    public abstract class Attacker : MonoBehaviour {
        protected float AttackDamage { get; set; }
        protected float AttackRechargeTimer { get; set; }
        protected float TimePassedSincePreviousAttack { get; set; }

        protected abstract void Attack(Attackable target = null);
    }
}
