using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete {
    public class MovableBasic : Movable {
        private void Awake() {
            RigidBody = GetComponent<Rigidbody>();
            MoveDirection = transform.position;
            MoveSpeed = 3.0f;
        }

        public override void Move(Vector3 moveDirection, float moveSpeed) {
            RigidBody.velocity = moveDirection * moveSpeed;
        }
    }
}
