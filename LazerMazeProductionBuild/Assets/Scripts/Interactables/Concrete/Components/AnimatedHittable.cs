using UnityEngine;


namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Component for objects that have a hurt animation
     */
    public class AnimatedHittable : AnimatedBasic {

        private static readonly int hitHash = Animator.StringToHash("bIsHurt");
        private bool bIsHurt = false;

        private void ChangeHitState() {
            bIsHurt = !bIsHurt;
            AnimatorController.SetBool(hitHash, bIsHurt);
        }

        public override void OnHitDisable() {
            if (bIsHurt) {
                ChangeHitState();
            }
        }

        public override void OnHitEnable() {
            if (!bIsHurt) {
                ChangeHitState();             
            }
        }
    }
}
