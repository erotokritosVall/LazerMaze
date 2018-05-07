using Assets.Scripts.Interactables.Abstract;
using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Component that moves with rigidbody
     */

     [RequireComponent(typeof(Rigidbody))]
    public class MovableWithRB :  Movable {
        private Rigidbody rigidBody;

        private void Awake() {
            rigidBody = GetComponent<Rigidbody>();
        }

        public override void Move() {
            rigidBody.velocity = MoveDirection * MoveSpeed;
        }
    }
}
