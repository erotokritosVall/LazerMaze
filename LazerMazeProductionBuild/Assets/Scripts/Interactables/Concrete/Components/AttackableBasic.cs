using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Component that doesn't play hurt animation when hit
     */
    public class AttackableBasic : Attackable {
        private void Awake() {
            MaxHP = currentHp = 50;
        }

        protected override void CheckHP() {
            if (currentHp <= 0) {
                Kill();
            }
        }

        protected override void Kill() {
            Destroy(gameObject);
        }

        public override void OnHit(float damage) {
            currentHp -= damage;
            CheckHP();
        }
    }
}
