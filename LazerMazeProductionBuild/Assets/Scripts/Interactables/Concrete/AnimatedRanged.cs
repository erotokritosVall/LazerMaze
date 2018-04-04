using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete {
    public class AnimatedRanged : AnimatedHittable {
        private readonly int shootHash = Animator.StringToHash("bIsShooting");
        private bool isShooting = false;

        private void ChangeBool() {
            isShooting = !isShooting;
            AnimatorController.SetBool(shootHash, isShooting);
        }

        public void OnShootEnable() {
            if (!isShooting && !isWalking) {
                ChangeBool();
            }
        }

        public void OnShootDisable() {
            if (isShooting) {
                ChangeBool();
            }
        }
    }
}
