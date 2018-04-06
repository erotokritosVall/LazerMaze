namespace Assets.Scripts.Interactables.Abstract {

    /**
     * Base class for every object that can be attacked
     */
    public abstract class Attackable : UserComponent {
        protected float CurrentHP { get; set; }
        public float MaxHP { get; set; }
        protected abstract void CheckHP();
        protected abstract void Kill();
        public abstract void OnHit(float damage);
    }
}
