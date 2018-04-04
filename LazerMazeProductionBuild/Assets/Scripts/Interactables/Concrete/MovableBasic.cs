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
            MoveDirection = Vector3.zero;
            MoveSpeed = 5.0f;
        }

        public override void Move() {
            RigidBody.velocity = MoveDirection * MoveSpeed;
        }
    }
}
