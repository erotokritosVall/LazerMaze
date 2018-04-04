using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interactables.Abstract;
using Assets.Scripts.Managers;

namespace Assets.Scripts.Interactables.Concrete {
    public class AnimatorController : Animated {
        private bool isFacingRight = true;
        private  readonly int xHash = Animator.StringToHash("xAxis");
        private  readonly int zHash = Animator.StringToHash("zAxis");

        protected readonly int walkHash = Animator.StringToHash("bIsWalking");
        protected bool isWalking = false;

        public float CachedX { get; private set; }
        public float CachedZ { get; private set; }

        private void Awake() {
            AnimatorController = GetComponent<Animator>();
            CachedX = AnimatorController.GetFloat(xHash);
            CachedZ = AnimatorController.GetFloat(zHash);
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
                    if (CachedX != xParam || CachedZ != zParam) {
                        CachedX = xParam;
                        CachedZ = zParam;
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
                    CachedX = xParam;
                    CachedZ = zParam;
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
    }
}
