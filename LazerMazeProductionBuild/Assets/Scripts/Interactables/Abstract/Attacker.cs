namespace Assets.Scripts.Interactables.Abstract {

    /**
     * Base class for every object that can attack
     */
        public abstract class Attacker : UserComponent {
        protected float TimePassedSincePreviousAttack { get; set; }
        public float AttackDamage { get; set; }
        public float AttackRechargeTimer { get; set; }
        public abstract void Attack(Attackable target = null);
    }
}
