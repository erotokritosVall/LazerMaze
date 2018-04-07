using UnityEngine;
using Assets.Scripts.Interactables.Abstract;
using Assets.Scripts.Interactables.Concrete.Controllers;

namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Component for ranged attackers
     */
    public class AttackerRanged : AttackerMelee {
        [SerializeField]
        private GameObject laser;
        private Vector3 laserDirection;
 
        protected override void Awake() {
            base.Awake();
            laserDirection = new Vector3(0, 0, 1);
        }

        private Quaternion LaserRotation() {
            return Quaternion.Euler(90, laserDirection.z * 90, 0);
        }

        private Vector3 LaserPosition() {
            return new Vector3(transform.position.x, transform.position.y - 0.02f, transform.position.z);
        }

        private void SetLaserDirection() {
            laserDirection.x = componentManager.animatorComponent.CachedX;
            laserDirection.z = componentManager.animatorComponent.CachedZ;
        }

        public override void Attack(Attackable target = null) {
            if (TimePassedSincePreviousAttack >= AttackRechargeTimer) {
                SetLaserDirection();
                componentManager.animatorComponent.OnShootEnable();
                LaserController laserController = Instantiate(laser, LaserPosition(), LaserRotation()).GetComponent<LaserController>();
                laserController.SetValues(laserDirection, tag);
                TimePassedSincePreviousAttack = 0.0f;
            }
        }
    }
}
