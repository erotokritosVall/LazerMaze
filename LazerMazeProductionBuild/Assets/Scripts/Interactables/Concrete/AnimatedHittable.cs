using UnityEngine;


namespace Assets.Scripts.Interactables.Concrete {

    /**
     * Component for objects that have a hurt animation
     */
    public class AnimatedHittable : AnimatedBasic {
        private readonly int hitHash = Animator.StringToHash("bIsHurt");
        public override void OnHitEnable() {
            if (!AnimatorController.GetBool(hitHash)) {
                AnimatorController.SetBool(hitHash, true);              
            }
        }

        public override void OnHitDisable() {
            if (AnimatorController.GetBool(hitHash)) {
                AnimatorController.SetBool(hitHash, false);
            }
        }
    }
}
