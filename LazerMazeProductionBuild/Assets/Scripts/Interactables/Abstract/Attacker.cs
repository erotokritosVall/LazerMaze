using UnityEngine;
using Assets.Scripts.Interactables.Concrete.Managers;

namespace Assets.Scripts.Interactables.Abstract {

    /**
     * Base class for every object that can attack
     */
        public abstract class Attacker : MonoBehaviour, IUserComponent {
        public ComponentManager componentManager { get; set; }
        protected float TimePassedSincePreviousAttack { get; set; }
        public float AttackDamage { get; set; }
        public float AttackRechargeTimer { get; set; }
        public abstract void Attack(Attackable target = null);
    }
}
