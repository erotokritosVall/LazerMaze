using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {

    /**
     * Base class for objects that are controlled by the player
     */

    public abstract class UserControlled : MonoBehaviour {

        protected float xInput;
        protected float zInput;
        protected abstract void GetInput();
    }
}
