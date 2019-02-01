using UnityEngine;
using System.Collections;
using Assets.Scripts.Interactables.Concrete.Controllers;

namespace Assets.Scripts.Interactables.Concrete.Components {

    /**
     * Component that handles gem functionality when being collected.
     * When touched , the gem makes a spiral movement around the player until it is close enough to him.
     */

    public class GemCollectable : MonoBehaviour {

        private void OnTriggerEnter(Collider other) {
            if (other.tag.Equals(PlayerController.Instance.tag)) {
                GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(SpiralMovement());
            }
        }

        //Archimedean spiral movement using polar coordinates (L = (a + bθ)*cos(θ) and converting them into euclidean.
        private IEnumerator SpiralMovement() {
            transform.position = PlayerController.Instance.transform.position + Vector3.forward;
            const int numOfTurns = 4;
            const float initialRadius = 1.0f;
            const float finishingDistance = 0.005f;
            const float shrinkRate = -initialRadius / (2 * Mathf.PI * numOfTurns);
            const float endingThetaAngle = -initialRadius / shrinkRate;
            float speed = 1.0f;
            float thetaAngle = Mathf.PI * 0.5f;
            Vector3 movementChange = Vector3.zero;
            while ((transform.position - PlayerController.Instance.transform.position).sqrMagnitude > finishingDistance) {
                movementChange.x = (initialRadius + shrinkRate * thetaAngle) * Mathf.Cos(thetaAngle);
                movementChange.z = (initialRadius + shrinkRate * thetaAngle) * Mathf.Sin(thetaAngle);
                transform.position = PlayerController.Instance.transform.position + movementChange * speed;
                thetaAngle = Mathf.LerpAngle(thetaAngle, endingThetaAngle, Time.deltaTime);
                transform.localScale -= Vector3.Lerp(Vector3.zero, Vector3.one, Time.deltaTime);
                speed -= Time.deltaTime * 0.5f;
                yield return null;
            }
            //TODO : OnGemCollected event trigger
        }
    }
}
