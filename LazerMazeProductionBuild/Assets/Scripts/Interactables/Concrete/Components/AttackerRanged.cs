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

        private void SetLaserDirection() {
            Animated animated = GetComponent<Animated>();
            laserDirection.x = animated.CachedX;
            laserDirection.z = animated.CachedZ;
        }

        public override void Attack() {
                SetLaserDirection();
                LaserController laserController = Instantiate(laser, transform.position, LaserRotation()).GetComponent<LaserController>();
                laserController.SetValues(laserDirection, tag, AttackDamage);
                timePassedSincePreviousAttack = 0.0f;
        }
    }
}
