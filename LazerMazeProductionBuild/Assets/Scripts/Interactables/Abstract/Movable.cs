using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {


    public abstract class Movable : UserComponent {
        public Vector3 MoveDirection;
        public float MoveSpeed { get; set; }
        protected Rigidbody RigidBody { get; set; }
        public abstract void Move(float x, float z);
    }
}
