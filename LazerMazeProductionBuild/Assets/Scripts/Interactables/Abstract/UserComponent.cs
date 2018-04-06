using Assets.Scripts.Interactables.Managers;
using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {

    /**
     * Base class for everything that is a component(script)
     */
    public abstract class UserComponent : MonoBehaviour {
        public ComponentManager componentManager { get; set; }
    }
}
