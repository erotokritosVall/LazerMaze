using UnityEngine;
using Assets.Scripts.Interactables.Abstract;

namespace Assets.Scripts.Interactables.Concrete {

    /**
     * Component for ranged attackers
     */
    public class AttackerRanged : AttackerMelee {
        [SerializeField]
        private GameObject laser;
        private Vector3 laserDirection;
 
        protected override void Awake() {
            base.Awake();
            SetLaserDirection(0, 1);
        }

        private Quaternion LaserRotation() {
            return Quaternion.Euler(90, laserDirection.z * 90, 0);
        }

        private Vector3 LaserPosition() {
            float x = transform.position.x + laserDirection.x / 2;
            float z = transform.position.z + laserDirection.z / 2;
            return new Vector3(x, 0.1f, z);
        }

        private void SetLaserDirection(float x, float z) {
            laserDirection.x = x;
            laserDirection.z = z;
        }

        public override void Attack(Attackable target = null) {
            if (TimePassedSincePreviousAttack >= AttackRechargeTimer) {
                SetLaserDirection(componentManager.animatorComponent.CachedX, 
                                  componentManager.animatorComponent.CachedZ);
                componentManager.animatorComponent.OnShootEnable();
                LaserController laserController = Instantiate(laser, LaserPosition(), LaserRotation()).GetComponent<LaserController>();
                laserController.SetValues(laserDirection, tag);
                TimePassedSincePreviousAttack = 0.0f;
            }
        }
    }
}
