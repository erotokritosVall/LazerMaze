using UnityEngine;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete {

    /**
     * Component that moves without move animations
     */
    [RequireComponent(typeof(Rigidbody))]
    public class MovableBasic : Movable {

        protected virtual void Awake() {
            RigidBody = GetComponent<Rigidbody>();
            MoveDirection = Vector3.zero;
            MoveSpeed = 5.0f;
        }

        public override void Move(float x, float z) {
            MoveDirection.x = x;
            MoveDirection.z = z;
            RigidBody.velocity = MoveDirection * MoveSpeed;
        }
    }
}
