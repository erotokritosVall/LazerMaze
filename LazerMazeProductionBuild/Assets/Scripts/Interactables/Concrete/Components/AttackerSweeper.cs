using UnityEngine;

namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Special component for Sweeper's attacks.
     */

    public class AttackerSweeper : AttackerMelee {

        [SerializeField]
        private GameObject explosionPrefab;

        public override void Attack() {
            Explosion explosion = Instantiate(explosionPrefab, transform.position, Quaternion.Euler(90,0,0)).GetComponent<Explosion>();
            explosion.AttackDamage = AttackDamage;
            Destroy(gameObject);
        }
    }
}
