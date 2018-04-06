using Assets.Scripts.Interactables.Abstract;
using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete {

    /**
     * Component for laser movement
     */
    public class MovableLaser : Movable {
        private void Awake() {
            MoveDirection = Vector3.zero;
            MoveSpeed = 5.0f;
        }

        public override void Move(float x, float z) {
            MoveDirection = new Vector3(x, 0, z);
            transform.position += MoveDirection * MoveSpeed * Time.deltaTime;
        }
    }
}
