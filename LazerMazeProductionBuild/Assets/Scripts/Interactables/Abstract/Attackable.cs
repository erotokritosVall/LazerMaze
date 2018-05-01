using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {

    /**
     * Base class for every object that can be attacked
     */
    public abstract class Attackable : MonoBehaviour {
        protected float currentHp;
        public float MaxHP { get; set; }
        protected abstract void CheckHP();
        protected abstract void Kill();
        public abstract void OnHit(float damage);
    }
}
