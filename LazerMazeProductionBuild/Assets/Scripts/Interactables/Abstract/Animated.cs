using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {

    [RequireComponent(typeof(Animator))]
    public abstract class Animated : MonoBehaviour {
        protected Animator AnimatorController { get; set; }
        public abstract void SetAnimatorParameters(float xParam, float zParam);
    }
}
