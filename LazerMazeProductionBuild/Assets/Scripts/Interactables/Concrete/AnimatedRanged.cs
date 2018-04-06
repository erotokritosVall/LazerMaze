using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete {

    /**
     * Components for objects that have a shoot animation
     */
    public class AnimatedRanged : AnimatedHittable {
        private readonly int shootHash = Animator.StringToHash("bIsShooting");
        private bool isShooting = false;

        private void ChangeBool() {
            isShooting = !isShooting;
            AnimatorController.SetBool(shootHash, isShooting);
        }

        public override void OnShootEnable() {
            if (!isShooting && !isWalking) {
                ChangeBool();
            }
        }

        public override void OnShootDisable() {
            if (isShooting) {
                ChangeBool();
            }
        }
    }
}
