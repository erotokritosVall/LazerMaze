using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {

    [RequireComponent(typeof(Rigidbody))]
    public abstract class Movable : MonoBehaviour {
        protected Vector3 MoveDirection { get; set; }
        protected float MoveSpeed { get; set; }
        protected Rigidbody RigidBody { get; set; }
        public abstract void Move(Vector3 moveDirection, float moveSpeed);
    }
}
