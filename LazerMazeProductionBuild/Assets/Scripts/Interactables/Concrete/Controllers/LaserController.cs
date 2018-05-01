using UnityEngine;
using Assets.Scripts.Interactables.Abstract;
using Assets.Scripts.Interactables.Concrete.Components;


namespace Assets.Scripts.Interactables.Concrete.Controllers {

    /**
     * Controller that handles the lasers spawned by the player and enemies
     */
     
    [RequireComponent(typeof(MovableWithRB))]
    public class LaserController : MonoBehaviour {
        Movable movableComponent;
        private string targetTag;
        private string parentTag;
        private float attackDamage;

        private void Awake() {
            movableComponent = GetComponent<Movable>();
        }

        private void FixedUpdate() {
            movableComponent.Move();
        }

        private void OnCollisionEnter(Collision collision) {
            if (collision.collider.CompareTag(targetTag)) {
                collision.collider.GetComponent<Attackable>().OnHit(attackDamage);
            }
            else if (collision.collider.CompareTag(parentTag)) {
                return;
            }
            Destroy(gameObject);
        }
        
        public void SetValues(Vector3 direction, string tag, float attackDamage) {
            const string enemyTag = "Enemy";
            const string playerTag = "Player";
            const float moveSpeed = 7.0f;
            movableComponent.MoveDirection = direction;
            movableComponent.MoveSpeed = moveSpeed;
            this.attackDamage = attackDamage;
            parentTag = tag;
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
