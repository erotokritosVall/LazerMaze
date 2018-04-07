using Assets.Scripts.Interactables.Concrete.Managers;
using UnityEngine;

namespace Assets.Scripts.Interactables.Abstract {

    /**
     * Base class for everything that is a component(script)
     */
    public interface IUserComponent {
        ComponentManager componentManager { get; set; }
    }
}
