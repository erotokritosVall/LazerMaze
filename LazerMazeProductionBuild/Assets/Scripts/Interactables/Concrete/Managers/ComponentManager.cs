using Assets.Scripts.Interactables.Abstract;
using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete.Managers {

    /**
     * Class that gives access to components so they can communicate with each other
     */
    public class ComponentManager : MonoBehaviour {
        public Animated animatorComponent { get; private set; }
        public Attackable attackableComponent { get; private set; }
        public Attacker attackerComponent { get; private set; }
        public Movable movableComponent { get; private set; }

        private void Awake() {
            animatorComponent = GetComponent<Animated>();
            attackableComponent = GetComponent<Attackable>();
            attackerComponent = GetComponent <Attacker>();
            movableComponent = GetComponent<Movable>();
            foreach(IUserComponent component in GetComponents<IUserComponent>()) {
                component.componentManager = this;
            }
        }
    }
}
