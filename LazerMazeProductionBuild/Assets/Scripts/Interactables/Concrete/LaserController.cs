using UnityEngine;
using Assets.Scripts.Interactables.Abstract;


namespace Assets.Scripts.Interactables.Concrete {

    /**
     * Controller that handles the lasers spawned by the player and enemies
     */
    [RequireComponent(typeof(MovableLaser))]
    [RequireComponent(typeof(AttackerMelee))]
    public class LaserController : UserComponent {
        private const string enemyTag = "Enemy";
        private float x, z;
        private string parentTag;

        private void Awake() {
            
        }
        private void FixedUpdate() {
            componentManager.movableComponent.Move(x, z);
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Enemy")) {
                componentManager.attackerComponent.Attack(other.GetComponent<Attackable>());
            }
            if (!other.CompareTag(parentTag)) {
                Destroy(gameObject);
            }
        }

        public void SetValues(Vector3 direction, string tag) {
            parentTag = tag;
            x = direction.x;
            z = direction.z;
            componentManager.movableComponent.Move(x, z);
            if (parentTag.CompareTo(enemyTag) == 0) {
                Color32 newColor = Color.red;
                GetComponent<SpriteRenderer>().color = newColor;
            }
        }
    }
}
