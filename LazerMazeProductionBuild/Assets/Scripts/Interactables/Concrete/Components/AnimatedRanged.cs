using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Components for objects that have a shoot animation
     */
    public class AnimatedRanged : AnimatedHittable {

        private static readonly int shootHash = Animator.StringToHash("bIsShooting");
        private bool isShooting = false;

        private void ChangeShootState() {
            isShooting = !isShooting;
            AnimatorController.SetBool(shootHash, isShooting);
        }

        public override void OnShootDisable() {
            if (isShooting) {
                ChangeShootState();
            }
        }

        public override void OnShootEnable() {
            if (!isShooting && !bIsWalking) {
                ChangeShootState();
            }
        }
    }
}
