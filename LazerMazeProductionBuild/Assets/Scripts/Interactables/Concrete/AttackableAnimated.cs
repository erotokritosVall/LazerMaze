namespace Assets.Scripts.Interactables.Concrete {

    /**
     * Component that plays hurt animation when being hit
     */
    public class AttackableAnimated : AttackableBasic {
        public override void OnHit(float damage) {
            componentManager.animatorComponent.OnHitEnable();
            base.OnHit(damage);
        }
    }
}
