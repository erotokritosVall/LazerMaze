using UnityEngine;
using Assets.Scripts.Interactables.Concrete.Controllers;

namespace Assets.Scripts.Managers {

    /**
     * Camera following player script
     */

    public class CameraManager : MonoBehaviour {

        private Transform playerTransform;
        private const float yPos = 6.0f;

        private void Start() {
            playerTransform = PlayerController.Instance.transform;
        }

        private void LateUpdate() {
            Vector3 newPosition = new Vector3(playerTransform.position.x, yPos, playerTransform.position.z);
            transform.position = newPosition;
        }
    }
}
