using UnityEngine;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Component for objects that have moving animations
     */
    public class AnimatedBasic : Animated {
        private bool bIsFacingRight = true;
        private readonly int xHash = Animator.StringToHash("xAxis");
        private readonly int zHash = Animator.StringToHash("zAxis");
        private readonly int walkHash = Animator.StringToHash("bIsWalking");

        protected bool bIsWalking = false;
        protected Animator AnimatorController { get; private set; }

        private void Awake() {
            AnimatorController = GetComponent<Animator>();
            CachedX = AnimatorController.GetFloat(xHash);
            CachedZ = AnimatorController.GetFloat(zHash);
        }

        private void FlipAnimation() {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
            bIsFacingRight = !bIsFacingRight;
        }

        private void SetValues(float xParam, float zParam) {
            CachedX = xParam;
            CachedZ = zParam;
            AnimatorController.SetFloat(xHash, xParam);
            AnimatorController.SetFloat(zHash, zParam);
            if (xParam > 0 && !bIsFacingRight) {
                FlipAnimation();
            } else if (xParam < 0 && bIsFacingRight) {
                FlipAnimation();
            }
        }

        private void ChangeWalkState() {
            bIsWalking = !bIsWalking;
            AnimatorController.SetBool(walkHash, bIsWalking);
        }

        public override void SetAnimatorParameters(float xParam, float zParam) {
            if (bIsWalking) {
                if (xParam == 0 && zParam == 0) {
                    ChangeWalkState();
                } else {
                    if (CachedX != xParam || CachedZ != zParam) {
                        SetValues(xParam, zParam);
                    }
                }               
            } else {
                if (xParam != 0 || zParam != 0) {
                    ChangeWalkState();
                    SetValues(xParam, zParam);
                }
            }
        }

        public override void OnHitEnable() { }
        public override void OnShootEnable() { }
        public override void OnShootDisable() { }
        public override void OnHitDisable() { }
    }
}
