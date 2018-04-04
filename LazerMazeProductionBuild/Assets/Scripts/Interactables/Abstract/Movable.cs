using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {

    [RequireComponent(typeof(Rigidbody))]
    public abstract class Movable : MonoBehaviour {
        public Vector3 MoveDirection { get; set; }
        public float MoveSpeed { get; set; }
        protected Rigidbody RigidBody { get; set; }
        public abstract void Move();
    }
}
