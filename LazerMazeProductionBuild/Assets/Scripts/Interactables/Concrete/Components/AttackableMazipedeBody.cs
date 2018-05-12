using Assets.Scripts.Interactables.Concrete.Controllers;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Special component for handling mazipede body
     */

    public class AttackableMazipedeBody : AttackableNotAnimated {

        public override void OnHit(float damage) {
            MazipedeHeadController head = transform.parent.GetChild(0).GetComponent<MazipedeHeadController>();
            if (head != null) {
                head.GetComponent<Attackable>().OnHit(damage);
            } else {
                base.OnHit(damage);
            }
        }

        protected override void Kill() {
            if (transform.parent.childCount > 1) {
                base.Kill();
            } else {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
