using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete {
    public class AttackableBasic : Attackable {
        private void Awake() {
            MaxHP = CurrentHP = 50;
        }

        public override void OnHit(float damage) {
            CurrentHP -= damage;
            CheckHP();
        }

        protected override void CheckHP() {
            if (CurrentHP <= 0) {
                Kill();
            }
        }

        protected override void Kill() {
            Destroy(gameObject);
        }
    }
}
