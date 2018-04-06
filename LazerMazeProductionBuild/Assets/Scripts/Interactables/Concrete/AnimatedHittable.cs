using UnityEngine;


namespace Assets.Scripts.Interactables.Concrete {

    /**
     * Component for objects that have a hurt animation
     */
    public class AnimatedHittable : AnimatedBasic {
        private readonly int hitHash = Animator.StringToHash("bIsHurt");
        private bool bIsHit = false;

        private void ChangeHitState() {
            bIsHit = !bIsHit;
            AnimatorController.SetBool(hitHash, bIsHit);
        }

        public override void OnHitDisable() {
            if (bIsHit) {
                ChangeHitState();
            }
        }

        public override void OnHitEnable() {
            if (!bIsHit) {
                ChangeHitState();             
            }
        }
    }
}
