using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete {

    /**
     * Component that doesn't play hurt animation when hit
     */
    public class AttackableBasic : Attackable {
        protected virtual void Awake() {
            MaxHP = CurrentHP = 50;
        }

        protected override void CheckHP() {
            if (CurrentHP <= 0) {
                Kill();
            }
        }

        protected override void Kill() {
            Destroy(gameObject);
        }

        public override void OnHit(float damage) {
            CurrentHP -= damage;
            CheckHP();
        }
    }
}
