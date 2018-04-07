using UnityEngine;
using Assets.Scripts.Interactables.Concrete.Managers;

namespace Assets.Scripts.Interactables.Abstract {


    public abstract class Movable : MonoBehaviour ,IUserComponent {
        public ComponentManager componentManager { get; set; }
        public Vector3 MoveDirection;
        public float MoveSpeed { get; set; }
        protected Rigidbody RigidBody { get; set; }
        public abstract void Move(float x, float z);
    }
}
