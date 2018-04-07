using UnityEngine;

namespace Assets.Scripts.Managers {

    /**
     * Handles the camera to follow the player
     */
    public class CameraManager : MonoBehaviour {
        private Transform player;
        private const float yPos = 4.0f;

        private void Awake() {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void LateUpdate() {
            Vector3 newPosition = new Vector3(player.position.x, yPos, player.position.z - 3);
            transform.position = newPosition;
        }
    }
}
