using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {
    /**
     * Base class for handling animations on an object
     */
        [RequireComponent(typeof(Animator))]
        public abstract class Animated : MonoBehaviour {

        public float CachedX { get; protected set; }
        public float CachedZ { get; protected set; }
        public abstract void SetAnimatorParameters(float xParam, float zParam);
        public abstract void OnHitEnable();
        public abstract void OnShootEnable();
        public abstract void OnHitDisable();
        public abstract void OnShootDisable();
    }
}
