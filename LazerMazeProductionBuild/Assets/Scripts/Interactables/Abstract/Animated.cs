using UnityEngine;
using Assets.Scripts.Interactables.Concrete.Managers;

namespace Assets.Scripts.Interactables.Abstract {
    /**
     * Base class for handling animations on an object
     */
        [RequireComponent(typeof(Animator))]
        public abstract class Animated : MonoBehaviour, IUserComponent {

        public ComponentManager componentManager { get; set; }
        protected float cachedX { get; set; }
        public float CachedX {
            get { return cachedX; }
        }
        protected float cachedZ { get; set; }
        public float CachedZ {
            get { return cachedZ; }
        }
        public abstract void SetAnimatorParameters(float xParam, float zParam);
        public abstract void OnHitEnable();
        public abstract void OnShootEnable();
        public abstract void OnHitDisable();
        public abstract void OnShootDisable();
    }
}
