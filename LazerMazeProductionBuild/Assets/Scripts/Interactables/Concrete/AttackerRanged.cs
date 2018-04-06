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
            laserDirection = Vector3.zero;
        }

        protected override void Update() {
            base.Update();
        }

        private Quaternion LaserRotation() {
            return Quaternion.Euler(90, laserDirection.z * 90, 0);
        }


        public override void Attack(Attackable target = null) {
            if (TimePassedSincePreviousAttack >= AttackRechargeTimer) {
                laserDirection = new Vector3(componentManager.animatorComponent.CachedX, 0, componentManager.animatorComponent.CachedZ);
                componentManager.animatorComponent.OnShootEnable();
                LaserController laserController = Instantiate(laser, transform.position, LaserRotation()).GetComponent<LaserController>();
                laserController.SetValues(laserDirection, tag);
                TimePassedSincePreviousAttack = 0.0f;
            }
        }
    }
}
