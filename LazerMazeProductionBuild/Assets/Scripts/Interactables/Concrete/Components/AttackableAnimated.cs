using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Component that plays hurt animation when being hit
     */
    public class AttackableAnimated : AttackableBasic {
        public override void OnHit(float damage) {
            GetComponent<Animated>().OnHitEnable();
            base.OnHit(damage);
        }
    }
}
