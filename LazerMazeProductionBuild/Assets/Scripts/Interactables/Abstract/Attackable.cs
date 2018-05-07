using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Interactables.Abstract {

    /**
     * Base class for every object that can be attacked
     */

    public abstract class Attackable : MonoBehaviour {

        protected float currentHp;
        protected int currentLives;
        public int MaxLives { get; set; }
        public float MaxHP { get; set; }
        protected abstract IEnumerator OnLifeLost();
        protected abstract IEnumerator OnZeroLives();
        protected abstract void CheckHP();
        protected abstract void Kill();
        public abstract void OnHit(float damage);
    }
}
