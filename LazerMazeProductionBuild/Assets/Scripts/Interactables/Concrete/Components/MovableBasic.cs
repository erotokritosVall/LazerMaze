using UnityEngine;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Component that moves without using rigidbody
     */
    public class MovableBasic : Movable {

        public override void Move() {
            transform.position += MoveDirection * MoveSpeed * Time.deltaTime;
        }
    }
}
