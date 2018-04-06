using UnityEngine;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete {
    /**
     * Component that controls and synchronizes player actions
     */
    public class PlayerController : UserControlled {
        private bool bShouldShoot = false;

        private void Update() {
            GetInput();
        }

        private void FixedUpdate() {
            componentManager.movableComponent.Move(XInput, ZInput);
        }

        private void LateUpdate() {
            if (bShouldShoot) {
                componentManager.attackerComponent.Attack();
                bShouldShoot = false;
            }
        }

        protected override void GetInput() {
            XInput = Input.GetAxisRaw("Horizontal");
            ZInput = Input.GetAxisRaw("Vertical");
            if (Input.GetMouseButtonDown(0)) {
                bShouldShoot = true;
            }
        }
    }
}
