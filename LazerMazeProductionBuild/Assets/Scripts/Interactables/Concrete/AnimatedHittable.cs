using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete {
    public class AnimatedHittable : AnimatorController {
         protected int hitHash { get; set; }

        private void Awake() {
           hitHash = Animator.StringToHash("bIsHurt");
        }

        public void OnHitEnable() {
            if (!AnimatorController.GetBool(hitHash)) {
                AnimatorController.SetBool(hitHash, true);
            }
        }

        public void OnHitDisable() {
            if (AnimatorController.GetBool(hitHash)) {
                AnimatorController.SetBool(hitHash, false);
            }
        }
    }
}
