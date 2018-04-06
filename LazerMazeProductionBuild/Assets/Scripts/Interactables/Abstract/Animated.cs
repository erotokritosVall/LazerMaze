using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {
    /**
     * Base class for handling animations on an object
     */
        [RequireComponent(typeof(Animator))]
        public abstract class Animated : UserComponent {

        protected float cachedX { get; set; }
        public float CachedX {
            get { return cachedX; }
        }
        protected float cachedZ { get; set; }
        public float CachedZ {
            get { return cachedZ; }
        }
        protected Animator AnimatorController { get; set; }
        public abstract void SetAnimatorParameters(float xParam, float zParam);
        public abstract void OnHitEnable();
        public abstract void OnHitDisable();
        public abstract void OnShootEnable();
        public abstract void OnShootDisable();
    }
}
