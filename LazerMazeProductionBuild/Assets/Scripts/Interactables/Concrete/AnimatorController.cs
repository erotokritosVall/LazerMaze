using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interactables.Abstract;
using Assets.Scripts.Managers;

namespace Assets.Scripts.Interactables.Concrete {
    public class AnimatorController : Animated {

        protected  int xHash = Animator.StringToHash("xAxis");
        protected  int zHash = Animator.StringToHash("zAxis");
        protected readonly int walkHash = Animator.StringToHash("bIsWalking");
        private bool isFacingRight = true;
        private IdleStateManager idleStateManager;

        private void Awake() {
            AnimatorController = GetComponent<Animator>();
        }

        private void Start() {
            idleStateManager = AnimatorController.GetBehaviour<IdleStateManager>();
        }

        private void FlipAnimation() {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
            isFacingRight = !isFacingRight;
        }

        public override void SetAnimatorParameters(float xParam, float zParam) {
            if (AnimatorController.GetBool(walkHash)) {
                if (xParam == 0 && zParam == 0) {
                    idleStateManager.SetValues(AnimatorController.GetFloat(xHash), AnimatorController.GetFloat(zHash));
                    AnimatorController.SetBool(walkHash, false);
                }
            } else {
                if (xParam != 0 || zParam != 0) {
                    AnimatorController.SetBool(walkHash, true);
                }
            }
            if (xParam > 0 && !isFacingRight) {
                FlipAnimation();
            }
            else if (xParam < 0 && isFacingRight) {
                FlipAnimation();
            }
            AnimatorController.SetFloat(xHash, xParam);
            AnimatorController.SetFloat(zHash, zParam);
        }
    }
}
