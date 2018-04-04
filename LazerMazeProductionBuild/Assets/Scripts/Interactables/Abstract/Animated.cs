using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {

    [RequireComponent(typeof(Animator))]
    public abstract class Animated : MonoBehaviour {
        protected Animator AnimatorController { get; set; }
        protected int walkHash { get; set; }
        protected abstract void SetAnimatorParameters(float xParam, float zParam);
    }
}
