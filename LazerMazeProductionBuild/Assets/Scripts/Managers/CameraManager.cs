using UnityEngine;

namespace Assets.Scripts.Managers {

    /**
     * Camera following player script
     */

    public class CameraManager : MonoBehaviour {

        private Transform player;
        private const float yPos = 6.0f;

        private void Awake() {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void LateUpdate() {
            Vector3 newPosition = new Vector3(player.position.x, yPos, player.position.z);
            transform.position = newPosition;
        }
    }
}
