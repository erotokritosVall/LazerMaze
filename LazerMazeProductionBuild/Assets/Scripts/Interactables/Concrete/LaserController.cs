using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interactables.Abstract;


namespace Assets.Scripts.Interactables.Concrete {
    [RequireComponent(typeof(MovableBasic))]
    [RequireComponent(typeof(AttackerMelee))]
    public class LaserController : MonoBehaviour {
        private MovableBasic movableBasic;
        private AttackerMelee attackerMelee;

        private void Awake() {
            movableBasic = GetComponent<MovableBasic>();
            attackerMelee = GetComponent<AttackerMelee>();
        }

        private void FixedUpdate() {
            movableBasic.Move();
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Enemy")) {
                attackerMelee.Attack(other.GetComponent<Attackable>());
            }
            Destroy(gameObject);
        }

        public void SetValues(Vector3 direction) {
            movableBasic.MoveDirection = direction;
        }
    }
}
