using UnityEngine;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Component that moves without move animations
     */
    [RequireComponent(typeof(Rigidbody))]
    public class MovableBasic : Movable {

        protected virtual void Awake() {
            RigidBody = GetComponent<Rigidbody>();
            MoveDirection = Vector3.zero;
            MoveSpeed = 8.0f;
        }

        public override void Move(float x, float z) {
            MoveDirection.x = x;
            MoveDirection.z = z;
            RigidBody.velocity = MoveDirection * MoveSpeed;
        }

        public override void StopMovement() {
            RigidBody.velocity = Vector3.zero;
        }
    }
}
