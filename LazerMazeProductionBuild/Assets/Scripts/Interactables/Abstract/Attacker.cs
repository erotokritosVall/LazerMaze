using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {

    /**
     * Base class for every object that can attack
     */

    public abstract class Attacker : MonoBehaviour {

        public float AttackDamage { get; set; }
        public float AttackRechargeTimer { get; set; }
        protected float timePassedSincePreviousAttack;
        public abstract void Attack();
        public abstract bool IsAbleToAttack();
        public abstract void Tick();
    }
}
