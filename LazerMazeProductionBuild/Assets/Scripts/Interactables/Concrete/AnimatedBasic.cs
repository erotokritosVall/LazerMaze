using UnityEngine;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete {

    /**
     * Component for objects that have moving animations
     */
    public class AnimatedBasic : Animated {
        private bool isFacingRight = true;
        private  readonly int xHash = Animator.StringToHash("xAxis");
        private  readonly int zHash = Animator.StringToHash("zAxis");

        protected readonly int walkHash = Animator.StringToHash("bIsWalking");
        protected bool isWalking = false;

        private void Awake() {
            AnimatorController = GetComponent<Animator>();
            cachedX = AnimatorController.GetFloat(xHash);
            cachedZ = AnimatorController.GetFloat(zHash);
        }

        private void FlipAnimation() {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
            isFacingRight = !isFacingRight;
        }

        public override void SetAnimatorParameters(float xParam, float zParam) {
            if (isWalking) {
                if (xParam == 0 && zParam == 0) {
                    isWalking = false;
                    AnimatorController.SetBool(walkHash, isWalking);
                } else {
                    if (cachedX != xParam || cachedZ != zParam) {
                        cachedX = xParam;
                        cachedZ = zParam;
                        AnimatorController.SetFloat(xHash, xParam);
                        AnimatorController.SetFloat(zHash, zParam);
                        if (xParam > 0 && !isFacingRight) {
                            FlipAnimation();
                        } else if (xParam < 0 && isFacingRight) {
                            FlipAnimation();
                        }
                    }
                }               
            } else {
                if (xParam != 0 || zParam != 0) {
                    cachedX = xParam;
                    cachedZ = zParam;
                    AnimatorController.SetFloat(xHash, xParam);
                    AnimatorController.SetFloat(zHash, zParam);
                    isWalking = true;
                    AnimatorController.SetBool(walkHash, isWalking);
                    if (xParam > 0 && !isFacingRight) {
                        FlipAnimation();
                    } else if (xParam < 0 && isFacingRight) {
                        FlipAnimation();
                    }
                }
            }
        }

        public override void OnHitEnable() { }
        public override void OnHitDisable() { }
        public override void OnShootEnable() { }
        public override void OnShootDisable() { }
    }
}
