using UnityEngine;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete {

    /**
     * Component that moves without move animations
     */
    [RequireComponent(typeof(Rigidbody))]
    public class MovableBasic : Movable {
        protected Rigidbody RigidBody { get; set; }

        protected virtual void Awake() {
            RigidBody = GetComponent<Rigidbody>();
            MoveDirection = Vector3.zero;
            MoveSpeed = 5.0f;
        }

        public override void Move(float x, float z) {
            MoveDirection = new Vector3(x, 0, z);
            RigidBody.velocity = MoveDirection * MoveSpeed;
        }
    }
}
