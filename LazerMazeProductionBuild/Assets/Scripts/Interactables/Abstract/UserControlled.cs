using Assets.Scripts.Interactables.Concrete.Managers;
using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {

    /**
     * Base class for objects that are controlled by the player
     */
    public abstract class UserControlled : MonoBehaviour,IUserComponent {
        public ComponentManager componentManager { get; set; }
        protected float XInput { get; set; }
        protected float ZInput { get; set; }
        protected abstract void GetInput();
    }
}
