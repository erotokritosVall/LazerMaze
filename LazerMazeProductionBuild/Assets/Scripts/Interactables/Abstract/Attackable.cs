using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {
    public abstract class Attackable : MonoBehaviour {
        public float MaxHP { get; set; }
        protected float CurrentHP { get; set; }

        public abstract void OnHit(float damage);
        protected abstract void CheckHP();
        protected abstract void Kill();
    }
}
