using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete {
    public class AnimatedRanged : AnimatedHittable {
        protected int shootHash { get; set; }
        private void Awake() {
            shootHash = Animator.StringToHash("bIsShooting");
        }

        public void OnShootEnable() {
            if (!AnimatorController.GetBool(shootHash)) {
                AnimatorController.SetBool(shootHash, true);
            }
        }

        public void OnShootDisable() {
            if (AnimatorController.GetBool(shootHash)) {
                AnimatorController.SetBool(shootHash, false);
            }
        }
    }
}
