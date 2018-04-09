using Assets.Scripts.Interactables.Abstract;
using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete.Components {
    public class EnemyMovable : Movable {

        public override void Move(float x, float z) {
            MoveDirection.x = x;
            MoveDirection.z = z;
            transform.position += MoveDirection * MoveSpeed * Time.deltaTime;
        }

        public override void StopMovement() { }
    }
}
