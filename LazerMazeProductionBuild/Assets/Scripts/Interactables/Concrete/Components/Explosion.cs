using UnityEngine;
using Assets.Scripts.Interactables.Abstract;
using Assets.Scripts.Interactables.Concrete.Controllers;

namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Component that handles explosion objects
     */

    public class Explosion : MonoBehaviour {

        public float AttackDamage { get; set; }

        public void OnAnimationFinish() {
            PlayerController.Instance.GetComponent<Attackable>().OnHit(AttackDamage);
            Destroy(gameObject);
        }
    }
}
