using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {

    /**
     * Base class for every object that moves
     */

    public abstract class Movable : MonoBehaviour {

        public Vector3 MoveDirection { get; set; }
        public float MoveSpeed { get; set; }
        public abstract void Move();
    }
}
