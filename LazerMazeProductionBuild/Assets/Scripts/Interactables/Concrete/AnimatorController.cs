using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete {
    public class AnimatorController : Animated {

        protected int xHash { get; set; }
        protected int zHash { get; set; }

        private void Awake() {
            AnimatorController = GetComponent<Animator>();
            xHash = Animator.StringToHash("xAxis");
            zHash = Animator.StringToHash("zAxis");
            walkHash = Animator.StringToHash("bIsWalking");
        }

        protected override void SetAnimatorParameters(float xParam, float zParam) {
            if (AnimatorController.GetBool(walkHash)) {
                if (xParam == 0 && zParam == 0) {
                    AnimatorController.SetBool(walkHash, false);
                }
            } else {
                if (xParam != 0 || zParam != 0) {
                    AnimatorController.SetBool(walkHash, true);
                }
            }
            AnimatorController.SetFloat(xHash, xParam);
            AnimatorController.SetFloat(zHash, zParam);
        }
    }
}
