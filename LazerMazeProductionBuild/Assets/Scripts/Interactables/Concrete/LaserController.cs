using UnityEngine;
using Assets.Scripts.Interactables.Abstract;


namespace Assets.Scripts.Interactables.Concrete {

    /**
     * Controller that handles the lasers spawned by the player and enemies
     */
    [RequireComponent(typeof(MovableBasic))]
    [RequireComponent(typeof(AttackerMelee))]
    public class LaserController : UserComponent {
        private string targetTag;
        private string parentTag;
        private float x, z;

        private void FixedUpdate() {
            componentManager.movableComponent.Move(x, z);
        }

        private void OnCollisionEnter(Collision collision) {
            if (collision.collider.CompareTag(targetTag)) {
                componentManager.attackerComponent.Attack(collision.collider.GetComponent<Attackable>());
            }
            else if (!collision.collider.CompareTag(parentTag)) {
                Destroy(gameObject);
            }
        }

        public void SetValues(Vector3 direction, string tag) {
        const string enemyTag = "Enemy";
        const string playerTag = "Player";
        parentTag = tag;
            x = direction.x;
            z = direction.z;
            if (parentTag.CompareTo(enemyTag) == 0) {
                Color32 newColor = Color.red;
                GetComponent<SpriteRenderer>().color = newColor;
                targetTag = playerTag;
            } else {
                targetTag = enemyTag;
            }
        }
    }
}
