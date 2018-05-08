namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Special component for Sweepers Attackable
     */

    public class AttackableSweeper : AttackableAnimated {

        public override void OnHit(float damage) {
            GetComponent<MovableWithoutRB>().MoveSpeed *= 0.5f;
            base.OnHit(damage);
        }
    }
}
