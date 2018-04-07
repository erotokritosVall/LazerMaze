using UnityEngine;
using Assets.Scripts.Interactables.Abstract;
using Assets.Scripts.Interactables.Concrete.Components;

namespace Assets.Scripts.Interactables.Concrete.Controllers {
    /**
     * Component that controls and synchronizes player actions
     */
     [RequireComponent(typeof(AnimatedRanged))]
     [RequireComponent(typeof(AttackableAnimated))]
     [RequireComponent(typeof(AttackerRanged))]
     [RequireComponent(typeof(MovableAnimated))]
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
